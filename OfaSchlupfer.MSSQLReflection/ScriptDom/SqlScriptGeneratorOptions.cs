namespace OfaSchlupfer.ScriptDom {
    public sealed class SqlScriptGeneratorOptions {
        private const KeywordCasing DefaultKeywordCasing = KeywordCasing.Uppercase;

        private const SqlVersion DefaultSqlVersion = SqlVersion.Sql90;

        private const SqlEngineType DefaultSqlEngineType = SqlEngineType.All;

        private const int DefaultIndentationSize = 4;

        private const bool DefaultIncludeSemicolons = false;

        private const bool DefaultAlignColumnDefinitionFields = true;

        private const bool DefaultNewLineBeforeFromClause = true;

        private const bool DefaultNewLineBeforeWhereClause = true;

        private const bool DefaultNewLineBeforeGroupByClause = true;

        private const bool DefaultNewLineBeforeOrderByClause = true;

        private const bool DefaultNewLineBeforeHavingClause = true;

        private const bool DefaultNewLineBeforeJoinClause = true;

        private const bool DefaultNewLineBeforeOffsetClause = true;

        private const bool DefaultNewLineBeforeOutputClause = true;

        private const bool DefaultAlignClauseBodies = true;

        private const bool DefaultMultilineSelectElementsList = true;

        private const bool DefaultMultilineWherePredicatesList = true;

        private const bool DefaultIndentViewBody = false;

        private const bool DefaultMultilineViewColumnsList = true;

        private const bool DefaultAsKeywordOnOwnLine = true;

        private const bool DefaultIndentSetClause = false;

        private const bool DefaultAlignSetClauseItem = true;

        private const bool DefaultMultilineSetClauseItems = true;

        private const bool DefaultMultilineInsertTargetsList = true;

        private const bool DefaultMultilineInsertSourcesList = true;

        private const bool DefaultNewLineBeforeOpenParenthesisInMultilineList = false;

        private const bool DefaultNewLineBeforeCloseParenthesisInMultilineList = true;

        private const int MinIndentationSize = 0;

        private KeywordCasing keywordCasing = KeywordCasing.Uppercase;

        private SqlVersion sqlVersion;

        private SqlEngineType sqlEngineType;

        private int indentationSize = 4;

        private bool includeSemicolons;

        private bool alignColumnDefinitionFields = true;

        private bool newLineBeforeFromClause = true;

        private bool newLineBeforeWhereClause = true;

        private bool newLineBeforeGroupByClause = true;

        private bool newLineBeforeOrderByClause = true;

        private bool newLineBeforeHavingClause = true;

        private bool newLineBeforeJoinClause = true;

        private bool newLineBeforeOffsetClause = true;

        private bool newLineBeforeOutputClause = true;

        private bool alignClauseBodies = true;

        private bool multilineSelectElementsList = true;

        private bool multilineWherePredicatesList = true;

        private bool indentViewBody;

        private bool multilineViewColumnsList = true;

        private bool asKeywordOnOwnLine = true;

        private bool indentSetClause;

        private bool alignSetClauseItem = true;

        private bool multilineSetClauseItems = true;

        private bool multilineInsertTargetsList = true;

        private bool multilineInsertSourcesList = true;

        private bool newLineBeforeOpenParenthesisInMultilineList;

        private bool newLineBeforeCloseParenthesisInMultilineList = true;

        public KeywordCasing KeywordCasing {
            get {
                return this.keywordCasing;
            }
            set {
                this.keywordCasing = value;
            }
        }

        public SqlVersion SqlVersion {
            get {
                return this.sqlVersion;
            }
            set {
                this.sqlVersion = value;
            }
        }

        public SqlEngineType SqlEngineType {
            get {
                return this.sqlEngineType;
            }
            set {
                this.sqlEngineType = value;
            }
        }

        public int IndentationSize {
            get {
                return this.indentationSize;
            }
            set {
                if (value < 0) {
                    this.indentationSize = 0;
                } else {
                    this.indentationSize = value;
                }
            }
        }

        public bool IncludeSemicolons {
            get {
                return this.includeSemicolons;
            }
            set {
                this.includeSemicolons = value;
            }
        }

        public bool AlignColumnDefinitionFields {
            get {
                return this.alignColumnDefinitionFields;
            }
            set {
                this.alignColumnDefinitionFields = value;
            }
        }

        public bool NewLineBeforeFromClause {
            get {
                return this.newLineBeforeFromClause;
            }
            set {
                this.newLineBeforeFromClause = value;
            }
        }

        public bool NewLineBeforeWhereClause {
            get {
                return this.newLineBeforeWhereClause;
            }
            set {
                this.newLineBeforeWhereClause = value;
            }
        }

        public bool NewLineBeforeGroupByClause {
            get {
                return this.newLineBeforeGroupByClause;
            }
            set {
                this.newLineBeforeGroupByClause = value;
            }
        }

        public bool NewLineBeforeOrderByClause {
            get {
                return this.newLineBeforeOrderByClause;
            }
            set {
                this.newLineBeforeOrderByClause = value;
            }
        }

        public bool NewLineBeforeHavingClause {
            get {
                return this.newLineBeforeHavingClause;
            }
            set {
                this.newLineBeforeHavingClause = value;
            }
        }

        public bool NewLineBeforeJoinClause {
            get {
                return this.newLineBeforeJoinClause;
            }
            set {
                this.newLineBeforeJoinClause = value;
            }
        }

        public bool NewLineBeforeOffsetClause {
            get {
                return this.newLineBeforeOffsetClause;
            }
            set {
                this.newLineBeforeOffsetClause = value;
            }
        }

        public bool NewLineBeforeOutputClause {
            get {
                return this.newLineBeforeOutputClause;
            }
            set {
                this.newLineBeforeOutputClause = value;
            }
        }

        public bool AlignClauseBodies {
            get {
                return this.alignClauseBodies;
            }
            set {
                this.alignClauseBodies = value;
            }
        }

        public bool MultilineSelectElementsList {
            get {
                return this.multilineSelectElementsList;
            }
            set {
                this.multilineSelectElementsList = value;
            }
        }

        public bool MultilineWherePredicatesList {
            get {
                return this.multilineWherePredicatesList;
            }
            set {
                this.multilineWherePredicatesList = value;
            }
        }

        public bool IndentViewBody {
            get {
                return this.indentViewBody;
            }
            set {
                this.indentViewBody = value;
            }
        }

        public bool MultilineViewColumnsList {
            get {
                return this.multilineViewColumnsList;
            }
            set {
                this.multilineViewColumnsList = value;
            }
        }

        public bool AsKeywordOnOwnLine {
            get {
                return this.asKeywordOnOwnLine;
            }
            set {
                this.asKeywordOnOwnLine = value;
            }
        }

        public bool IndentSetClause {
            get {
                return this.indentSetClause;
            }
            set {
                this.indentSetClause = value;
            }
        }

        public bool AlignSetClauseItem {
            get {
                return this.alignSetClauseItem;
            }
            set {
                this.alignSetClauseItem = value;
            }
        }

        public bool MultilineSetClauseItems {
            get {
                return this.multilineSetClauseItems;
            }
            set {
                this.multilineSetClauseItems = value;
            }
        }

        public bool MultilineInsertTargetsList {
            get {
                return this.multilineInsertTargetsList;
            }
            set {
                this.multilineInsertTargetsList = value;
            }
        }

        public bool MultilineInsertSourcesList {
            get {
                return this.multilineInsertSourcesList;
            }
            set {
                this.multilineInsertSourcesList = value;
            }
        }

        public bool NewLineBeforeOpenParenthesisInMultilineList {
            get {
                return this.newLineBeforeOpenParenthesisInMultilineList;
            }
            set {
                this.newLineBeforeOpenParenthesisInMultilineList = value;
            }
        }

        public bool NewLineBeforeCloseParenthesisInMultilineList {
            get {
                return this.newLineBeforeCloseParenthesisInMultilineList;
            }
            set {
                this.newLineBeforeCloseParenthesisInMultilineList = value;
            }
        }

        public void Reset() {
            this.KeywordCasing = KeywordCasing.Uppercase;
            this.SqlVersion = SqlVersion.Sql90;
            this.SqlEngineType = SqlEngineType.All;
            this.IndentationSize = 4;
            this.IncludeSemicolons = false;
            this.AlignColumnDefinitionFields = true;
            this.NewLineBeforeFromClause = true;
            this.NewLineBeforeWhereClause = true;
            this.NewLineBeforeGroupByClause = true;
            this.NewLineBeforeOrderByClause = true;
            this.NewLineBeforeHavingClause = true;
            this.NewLineBeforeJoinClause = true;
            this.NewLineBeforeOffsetClause = true;
            this.NewLineBeforeOutputClause = true;
            this.AlignClauseBodies = true;
            this.MultilineSelectElementsList = true;
            this.MultilineWherePredicatesList = true;
            this.IndentViewBody = false;
            this.MultilineViewColumnsList = true;
            this.AsKeywordOnOwnLine = true;
            this.IndentSetClause = false;
            this.AlignSetClauseItem = true;
            this.MultilineSetClauseItems = true;
            this.MultilineInsertTargetsList = true;
            this.MultilineInsertSourcesList = true;
            this.NewLineBeforeOpenParenthesisInMultilineList = false;
            this.NewLineBeforeCloseParenthesisInMultilineList = true;
        }
    }
}
