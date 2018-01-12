using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OfaSchlupfer.ScriptDom.ScriptGenerator {
    internal class ScriptWriter {
        internal abstract class ScriptWriterElement {
            public ScriptWriterElementType ElementType {
                get;
                protected set;
            }
        }

        internal class AlignmentPointData : ScriptWriterElement {
            private Dictionary<AlignmentPointData, int> _leftPoints;

            private HashSet<AlignmentPointData> _rightPoints;

            public int Offset {
                get;
                set;
            }

            public string Name {
                get;
                private set;
            }

            public bool HasNoLeftPoints {
                get {
                    return this._leftPoints.Count == 0;
                }
            }

            public HashSet<AlignmentPointData> RightPoints {
                get {
                    return this._rightPoints;
                }
            }

            public AlignmentPointData(string name) {
                base.ElementType = ScriptWriterElementType.AlignmentPoint;
                this.Name = name;
                this._leftPoints = new Dictionary<AlignmentPointData, int>();
                this._rightPoints = new HashSet<AlignmentPointData>();
            }

            public void AddLeftPoint(AlignmentPointData ap, int width) {
                int num = default(int);
                if (!this._leftPoints.TryGetValue(ap, out num)) {
                    this._leftPoints.Add(ap, width);
                } else if (num < width) {
                    this._leftPoints[ap] = width;
                }
            }

            public void AddRightPoint(AlignmentPointData ap) {
                this._rightPoints.Add(ap);
            }

            public void AlignAndRemoveLeftPoint(AlignmentPointData ap) {
                int num = default(int);
                if (this._leftPoints.TryGetValue(ap, out num)) {
                    this.Offset = Math.Max(ap.Offset + num, this.Offset);
                    this._leftPoints.Remove(ap);
                }
            }
        }

        [DebuggerDisplay("NewLine==========")]
        internal class NewLineElement : ScriptWriterElement {
            public NewLineElement() {
                base.ElementType = ScriptWriterElementType.NewLine;
            }
        }

        internal enum ScriptWriterElementType {
            AlignmentPoint,
            Token,
            NewLine
        }

        [DebuggerDisplay("Token({_token.Text})")]
        internal class TokenWrapper : ScriptWriterElement {
            private TSqlParserToken _token;

            public TSqlParserToken Token {
                get {
                    return this._token;
                }
            }

            public TokenWrapper(TSqlParserToken token) {
                this._token = token;
                base.ElementType = ScriptWriterElementType.Token;
            }
        }

        private static NewLineElement _newLine = new NewLineElement();

        private static TSqlParserToken _newLineToken = new TSqlParserToken(TSqlTokenType.WhiteSpace, Environment.NewLine);

        private SqlScriptGeneratorOptions _options;

        private Dictionary<AlignmentPoint, AlignmentPointData> _alignmentPointDataMap;

        private Dictionary<string, AlignmentPoint> _alignmentPointNameMapForCurrentScope;

        private Stack<Dictionary<string, AlignmentPoint>> _alignmentPointNameMaps;

        private List<ScriptWriterElement> _scriptWriterElements;

        private Stack<AlignmentPoint> _newLineAlignmentPoints;

        public ScriptWriter(SqlScriptGeneratorOptions options) {
            this._options = options;
            this._alignmentPointDataMap = new Dictionary<AlignmentPoint, AlignmentPointData>();
            this._alignmentPointNameMapForCurrentScope = new Dictionary<string, AlignmentPoint>();
            this._alignmentPointNameMaps = new Stack<Dictionary<string, AlignmentPoint>>();
            this._scriptWriterElements = new List<ScriptWriterElement>();
            this._newLineAlignmentPoints = new Stack<AlignmentPoint>();
        }

        public void AddKeyword(TSqlTokenType keywordId) {
            string tokenString = ScriptGeneratorSupporter.GetTokenString(keywordId, this._options.KeywordCasing);
            TSqlParserToken token = new TSqlParserToken(keywordId, tokenString);
            this.AddToken(token);
        }

        public void AddIdentifierWithCasing(string text) {
            ScriptGeneratorSupporter.CheckForNullReference(text, "text");
            this.AddIdentifier(text, true);
        }

        public void AddIdentifierWithoutCasing(string text) {
            ScriptGeneratorSupporter.CheckForNullReference(text, "text");
            this.AddIdentifier(text, false);
        }

        public void AddToken(TSqlParserToken token) {
            ScriptGeneratorSupporter.CheckForNullReference(token, "token");
            this.AddTokenWrapper(new TokenWrapper(token));
        }

        public void NewLine() {
            this.AddNewLine();
            if (this._newLineAlignmentPoints.Count > 0) {
                this.Mark(this._newLineAlignmentPoints.Peek());
            }
        }

        public void Indent(int size) {
            this.AddSpace(size);
        }

        public void Mark(AlignmentPoint ap) {
            if (!string.IsNullOrEmpty(ap.Name) && !this._alignmentPointNameMapForCurrentScope.ContainsKey(ap.Name)) {
                this._alignmentPointNameMapForCurrentScope.Add(ap.Name, ap);
            }
            this.AddAlignmentPoint(ap);
        }

        public void PushNewLineAlignmentPoint(AlignmentPoint ap) {
            this._newLineAlignmentPoints.Push(ap);
            this._alignmentPointNameMaps.Push(this._alignmentPointNameMapForCurrentScope);
            this._alignmentPointNameMapForCurrentScope = new Dictionary<string, AlignmentPoint>();
        }

        public void PopNewLineAlignmentPoint() {
            this._newLineAlignmentPoints.Pop();
            this._alignmentPointNameMapForCurrentScope = this._alignmentPointNameMaps.Pop();
        }

        public AlignmentPoint FindOrCreateAlignmentPoint(string name) {
            AlignmentPoint alignmentPoint = null;
            if (!this._alignmentPointNameMapForCurrentScope.TryGetValue(name, out alignmentPoint)) {
                alignmentPoint = null;
            }
            if (alignmentPoint == null) {
                alignmentPoint = new AlignmentPoint(name);
            }
            return alignmentPoint;
        }

        public void WriteTo(TextWriter writer) {
            List<TSqlParserToken> list = this.TryGetAlignedTokens();
            foreach (TSqlParserToken item in list) {
                writer.Write(item.Text);
            }
            writer.Flush();
        }

        public void WriteTo(IList<TSqlParserToken> tokens) {
            List<TSqlParserToken> list = this.TryGetAlignedTokens();
            foreach (TSqlParserToken item in list) {
                tokens.Add(item);
            }
        }

        private void AddIdentifier(string text, bool applyCasing) {
            if (applyCasing) {
                text = ScriptGeneratorSupporter.GetCasedString(text, this._options.KeywordCasing);
            }
            TSqlParserToken token = new TSqlParserToken(TSqlTokenType.Identifier, text);
            this.AddToken(token);
        }

        private void AddSpace(int count) {
            this.AddToken(ScriptGeneratorSupporter.CreateWhitespaceToken(count));
        }

        private void AddTokenWrapper(TokenWrapper token) {
            this._scriptWriterElements.Add(token);
        }

        private void AddAlignmentPoint(AlignmentPoint ap) {
            this._scriptWriterElements.Add(this.FindOrCreateAlignmentPointData(ap));
        }

        private void AddNewLine() {
            this._scriptWriterElements.Add(ScriptWriter._newLine);
        }

        private ScriptWriterElement FindOrCreateAlignmentPointData(AlignmentPoint ap) {
            AlignmentPointData alignmentPointData = default(AlignmentPointData);
            if (!this._alignmentPointDataMap.TryGetValue(ap, out alignmentPointData)) {
                alignmentPointData = new AlignmentPointData(ap.Name);
                this._alignmentPointDataMap.Add(ap, alignmentPointData);
            }
            return alignmentPointData;
        }

        private List<TSqlParserToken> TryGetAlignedTokens() {
            List<TSqlParserToken> list = this.Align();
            if (list == null) {
                list = this.GetAllTokens();
            }
            return list;
        }

        private List<TSqlParserToken> Align() {
            HashSet<AlignmentPointData> hashSet = new HashSet<AlignmentPointData>();
            int num = 0;
            AlignmentPointData alignmentPointData = null;
            for (int i = 0; i < this._scriptWriterElements.Count; i++) {
                ScriptWriterElement scriptWriterElement = this._scriptWriterElements[i];
                switch (scriptWriterElement.ElementType) {
                    case ScriptWriterElementType.AlignmentPoint: {
                            AlignmentPointData alignmentPointData2 = scriptWriterElement as AlignmentPointData;
                            hashSet.Add(alignmentPointData2);
                            if (alignmentPointData != null) {
                                alignmentPointData2.AddLeftPoint(alignmentPointData, num);
                                alignmentPointData.AddRightPoint(alignmentPointData2);
                            } else {
                                alignmentPointData2.Offset = Math.Max(alignmentPointData2.Offset, num);
                            }
                            num = 0;
                            alignmentPointData = alignmentPointData2;
                            break;
                        }
                    case ScriptWriterElementType.Token: {
                            TokenWrapper tokenWrapper = scriptWriterElement as TokenWrapper;
                            if (tokenWrapper != null && tokenWrapper.Token != null && tokenWrapper.Token.Text != null) {
                                num += tokenWrapper.Token.Text.Length;
                            }
                            break;
                        }
                    case ScriptWriterElementType.NewLine:
                        num = 0;
                        alignmentPointData = null;
                        break;
                }
            }
            while (true) {
                if (hashSet.Count == 0) {
                    break;
                }
                AlignmentPointData alignmentPointData3 = ScriptWriter.FindOneAlignmentPointWithOutDependent(hashSet);
                if (alignmentPointData3 == null) {
                    return null;
                }
                HashSet<AlignmentPointData> rightPoints = alignmentPointData3.RightPoints;
                foreach (AlignmentPointData item in rightPoints) {
                    item.AlignAndRemoveLeftPoint(alignmentPointData3);
                }
                hashSet.Remove(alignmentPointData3);
            }
            List<TSqlParserToken> list = new List<TSqlParserToken>();
            int num2 = 0;
            for (int j = 0; j < this._scriptWriterElements.Count; j++) {
                ScriptWriterElement scriptWriterElement2 = this._scriptWriterElements[j];
                switch (scriptWriterElement2.ElementType) {
                    case ScriptWriterElementType.AlignmentPoint: {
                            AlignmentPointData alignmentPointData4 = scriptWriterElement2 as AlignmentPointData;
                            if (alignmentPointData4.Offset > num2) {
                                list.Add(ScriptGeneratorSupporter.CreateWhitespaceToken(alignmentPointData4.Offset - num2));
                            }
                            num2 = alignmentPointData4.Offset;
                            break;
                        }
                    case ScriptWriterElementType.Token: {
                            TokenWrapper tokenWrapper2 = scriptWriterElement2 as TokenWrapper;
                            if (tokenWrapper2 != null && tokenWrapper2.Token != null && tokenWrapper2.Token.Text != null) {
                                list.Add(tokenWrapper2.Token);
                                num2 += tokenWrapper2.Token.Text.Length;
                            }
                            break;
                        }
                    case ScriptWriterElementType.NewLine:
                        list.Add(ScriptWriter._newLineToken);
                        num2 = 0;
                        break;
                }
            }
            return list;
        }

        private List<TSqlParserToken> GetAllTokens() {
            List<TSqlParserToken> list = new List<TSqlParserToken>();
            for (int i = 0; i < this._scriptWriterElements.Count; i++) {
                ScriptWriterElement scriptWriterElement = this._scriptWriterElements[i];
                switch (scriptWriterElement.ElementType) {
                    case ScriptWriterElementType.Token: {
                            TokenWrapper tokenWrapper = scriptWriterElement as TokenWrapper;
                            list.Add(tokenWrapper.Token);
                            break;
                        }
                    case ScriptWriterElementType.NewLine:
                        list.Add(ScriptWriter._newLineToken);
                        break;
                }
            }
            return list;
        }

        private static AlignmentPointData FindOneAlignmentPointWithOutDependent(HashSet<AlignmentPointData> points) {
            AlignmentPointData result = null;
            foreach (AlignmentPointData point in points) {
                if (point.HasNoLeftPoints) {
                    return point;
                }
            }
            return result;
        }
    }
}
