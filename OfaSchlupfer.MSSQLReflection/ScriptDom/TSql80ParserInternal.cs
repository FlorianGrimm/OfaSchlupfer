#pragma warning disable CS0219

namespace OfaSchlupfer.ScriptDom {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using antlr;
    using antlr.collections.impl;

    internal class TSql80ParserInternal : TSql80ParserBaseInternal {
        public const int EOF = 1;

        public const int NULL_TREE_LOOKAHEAD = 3;

        public const int Add = 4;

        public const int All = 5;

        public const int Alter = 6;

        public const int And = 7;

        public const int Any = 8;

        public const int As = 9;

        public const int Asc = 10;

        public const int Authorization = 11;

        public const int Backup = 12;

        public const int Begin = 13;

        public const int Between = 14;

        public const int Break = 15;

        public const int Browse = 16;

        public const int Bulk = 17;

        public const int By = 18;

        public const int Cascade = 19;

        public const int Case = 20;

        public const int Check = 21;

        public const int Checkpoint = 22;

        public const int Close = 23;

        public const int Clustered = 24;

        public const int Coalesce = 25;

        public const int Collate = 26;

        public const int Column = 27;

        public const int Commit = 28;

        public const int Compute = 29;

        public const int Constraint = 30;

        public const int Contains = 31;

        public const int ContainsTable = 32;

        public const int Continue = 33;

        public const int Convert = 34;

        public const int Create = 35;

        public const int Cross = 36;

        public const int Current = 37;

        public const int CurrentDate = 38;

        public const int CurrentTime = 39;

        public const int CurrentTimestamp = 40;

        public const int CurrentUser = 41;

        public const int Cursor = 42;

        public const int Database = 43;

        public const int Dbcc = 44;

        public const int Deallocate = 45;

        public const int Declare = 46;

        public const int Default = 47;

        public const int Delete = 48;

        public const int Deny = 49;

        public const int Desc = 50;

        public const int Distinct = 51;

        public const int Distributed = 52;

        public const int Double = 53;

        public const int Drop = 54;

        public const int Else = 55;

        public const int End = 56;

        public const int Errlvl = 57;

        public const int Escape = 58;

        public const int Except = 59;

        public const int Exec = 60;

        public const int Execute = 61;

        public const int Exists = 62;

        public const int Exit = 63;

        public const int Fetch = 64;

        public const int File = 65;

        public const int FillFactor = 66;

        public const int For = 67;

        public const int Foreign = 68;

        public const int FreeText = 69;

        public const int FreeTextTable = 70;

        public const int From = 71;

        public const int Full = 72;

        public const int Function = 73;

        public const int GoTo = 74;

        public const int Grant = 75;

        public const int Group = 76;

        public const int Having = 77;

        public const int HoldLock = 78;

        public const int Identity = 79;

        public const int IdentityInsert = 80;

        public const int IdentityColumn = 81;

        public const int If = 82;

        public const int In = 83;

        public const int Index = 84;

        public const int Inner = 85;

        public const int Insert = 86;

        public const int Intersect = 87;

        public const int Into = 88;

        public const int Is = 89;

        public const int Join = 90;

        public const int Key = 91;

        public const int Kill = 92;

        public const int Left = 93;

        public const int Like = 94;

        public const int LineNo = 95;

        public const int National = 96;

        public const int NoCheck = 97;

        public const int NonClustered = 98;

        public const int Not = 99;

        public const int Null = 100;

        public const int NullIf = 101;

        public const int Of = 102;

        public const int Off = 103;

        public const int Offsets = 104;

        public const int On = 105;

        public const int Open = 106;

        public const int OpenDataSource = 107;

        public const int OpenQuery = 108;

        public const int OpenRowSet = 109;

        public const int OpenXml = 110;

        public const int Option = 111;

        public const int Or = 112;

        public const int Order = 113;

        public const int Outer = 114;

        public const int Over = 115;

        public const int Percent = 116;

        public const int Plan = 117;

        public const int Primary = 118;

        public const int Print = 119;

        public const int Proc = 120;

        public const int Procedure = 121;

        public const int Public = 122;

        public const int Raiserror = 123;

        public const int Read = 124;

        public const int ReadText = 125;

        public const int Reconfigure = 126;

        public const int References = 127;

        public const int Replication = 128;

        public const int Restore = 129;

        public const int Restrict = 130;

        public const int Return = 131;

        public const int Revoke = 132;

        public const int Right = 133;

        public const int Rollback = 134;

        public const int RowCount = 135;

        public const int RowGuidColumn = 136;

        public const int Rule = 137;

        public const int Save = 138;

        public const int Schema = 139;

        public const int Select = 140;

        public const int SessionUser = 141;

        public const int Set = 142;

        public const int SetUser = 143;

        public const int Shutdown = 144;

        public const int Some = 145;

        public const int Statistics = 146;

        public const int SystemUser = 147;

        public const int Table = 148;

        public const int TextSize = 149;

        public const int Then = 150;

        public const int To = 151;

        public const int Top = 152;

        public const int Tran = 153;

        public const int Transaction = 154;

        public const int Trigger = 155;

        public const int Truncate = 156;

        public const int TSEqual = 157;

        public const int Union = 158;

        public const int Unique = 159;

        public const int Update = 160;

        public const int UpdateText = 161;

        public const int Use = 162;

        public const int User = 163;

        public const int Values = 164;

        public const int Varying = 165;

        public const int View = 166;

        public const int WaitFor = 167;

        public const int When = 168;

        public const int Where = 169;

        public const int While = 170;

        public const int With = 171;

        public const int WriteText = 172;

        public const int Disk = 173;

        public const int Precision = 174;

        public const int External = 175;

        public const int Revert = 176;

        public const int Pivot = 177;

        public const int Unpivot = 178;

        public const int TableSample = 179;

        public const int Dump = 180;

        public const int Load = 181;

        public const int Merge = 182;

        public const int StopList = 183;

        public const int SemanticKeyPhraseTable = 184;

        public const int SemanticSimilarityTable = 185;

        public const int SemanticSimilarityDetailsTable = 186;

        public const int TryConvert = 187;

        public const int Bang = 188;

        public const int PercentSign = 189;

        public const int Ampersand = 190;

        public const int LeftParenthesis = 191;

        public const int RightParenthesis = 192;

        public const int LeftCurly = 193;

        public const int RightCurly = 194;

        public const int Star = 195;

        public const int MultiplyEquals = 196;

        public const int Plus = 197;

        public const int Comma = 198;

        public const int Minus = 199;

        public const int Dot = 200;

        public const int Divide = 201;

        public const int Colon = 202;

        public const int DoubleColon = 203;

        public const int Semicolon = 204;

        public const int LessThan = 205;

        public const int EqualsSign = 206;

        public const int RightOuterJoin = 207;

        public const int GreaterThan = 208;

        public const int Circumflex = 209;

        public const int VerticalLine = 210;

        public const int Tilde = 211;

        public const int AddEquals = 212;

        public const int SubtractEquals = 213;

        public const int DivideEquals = 214;

        public const int ModEquals = 215;

        public const int BitwiseAndEquals = 216;

        public const int BitwiseOrEquals = 217;

        public const int BitwiseXorEquals = 218;

        public const int Go = 219;

        public const int Label = 220;

        public const int Integer = 221;

        public const int Numeric = 222;

        public const int Real = 223;

        public const int HexLiteral = 224;

        public const int Money = 225;

        public const int SqlCommandIdentifier = 226;

        public const int PseudoColumn = 227;

        public const int DollarPartition = 228;

        public const int AsciiStringOrQuotedIdentifier = 229;

        public const int AsciiStringLiteral = 230;

        public const int UnicodeStringLiteral = 231;

        public const int Identifier = 232;

        public const int QuotedIdentifier = 233;

        public const int Variable = 234;

        public const int OdbcInitiator = 235;

        public const int ProcNameSemicolon = 236;

        public const int SingleLineComment = 237;

        public const int MultilineComment = 238;

        public const int WhiteSpace = 239;

        public static readonly string[] tokenNames_ = new string[240]
        {
            "\"<0>\"",
            "\"EOF\"",
            "\"<2>\"",
            "\"NULL_TREE_LOOKAHEAD\"",
            "\"add\"",
            "\"all\"",
            "\"alter\"",
            "\"and\"",
            "\"any\"",
            "\"as\"",
            "\"asc\"",
            "\"authorization\"",
            "\"backup\"",
            "\"begin\"",
            "\"between\"",
            "\"break\"",
            "\"browse\"",
            "\"bulk\"",
            "\"by\"",
            "\"cascade\"",
            "\"case\"",
            "\"check\"",
            "\"checkpoint\"",
            "\"close\"",
            "\"clustered\"",
            "\"coalesce\"",
            "\"collate\"",
            "\"column\"",
            "\"commit\"",
            "\"compute\"",
            "\"constraint\"",
            "\"contains\"",
            "\"containstable\"",
            "\"continue\"",
            "\"convert\"",
            "\"create\"",
            "\"cross\"",
            "\"current\"",
            "\"current_date\"",
            "\"current_time\"",
            "\"current_timestamp\"",
            "\"current_user\"",
            "\"cursor\"",
            "\"database\"",
            "\"dbcc\"",
            "\"deallocate\"",
            "\"declare\"",
            "\"default\"",
            "\"delete\"",
            "\"deny\"",
            "\"desc\"",
            "\"distinct\"",
            "\"distributed\"",
            "\"double\"",
            "\"drop\"",
            "\"else\"",
            "\"end\"",
            "\"errlvl\"",
            "\"escape\"",
            "\"except\"",
            "\"exec\"",
            "\"execute\"",
            "\"exists\"",
            "\"exit\"",
            "\"fetch\"",
            "\"file\"",
            "\"fillfactor\"",
            "\"for\"",
            "\"foreign\"",
            "\"freetext\"",
            "\"freetexttable\"",
            "\"from\"",
            "\"full\"",
            "\"function\"",
            "\"goto\"",
            "\"grant\"",
            "\"group\"",
            "\"having\"",
            "\"holdlock\"",
            "\"identity\"",
            "\"identity_insert\"",
            "\"identitycol\"",
            "\"if\"",
            "\"in\"",
            "\"index\"",
            "\"inner\"",
            "\"insert\"",
            "\"intersect\"",
            "\"into\"",
            "\"is\"",
            "\"join\"",
            "\"key\"",
            "\"kill\"",
            "\"left\"",
            "\"like\"",
            "\"lineno\"",
            "\"national\"",
            "\"nocheck\"",
            "\"nonclustered\"",
            "\"not\"",
            "\"null\"",
            "\"nullif\"",
            "\"of\"",
            "\"off\"",
            "\"offsets\"",
            "\"on\"",
            "\"open\"",
            "\"opendatasource\"",
            "\"openquery\"",
            "\"openrowset\"",
            "\"openxml\"",
            "\"option\"",
            "\"or\"",
            "\"order\"",
            "\"outer\"",
            "\"over\"",
            "\"percent\"",
            "\"plan\"",
            "\"primary\"",
            "\"print\"",
            "\"proc\"",
            "\"procedure\"",
            "\"public\"",
            "\"raiserror\"",
            "\"read\"",
            "\"readtext\"",
            "\"reconfigure\"",
            "\"references\"",
            "\"replication\"",
            "\"restore\"",
            "\"restrict\"",
            "\"return\"",
            "\"revoke\"",
            "\"right\"",
            "\"rollback\"",
            "\"rowcount\"",
            "\"rowguidcol\"",
            "\"rule\"",
            "\"save\"",
            "\"schema\"",
            "\"select\"",
            "\"session_user\"",
            "\"set\"",
            "\"setuser\"",
            "\"shutdown\"",
            "\"some\"",
            "\"statistics\"",
            "\"system_user\"",
            "\"table\"",
            "\"textsize\"",
            "\"then\"",
            "\"to\"",
            "\"top\"",
            "\"tran\"",
            "\"transaction\"",
            "\"trigger\"",
            "\"truncate\"",
            "\"tsequal\"",
            "\"union\"",
            "\"unique\"",
            "\"update\"",
            "\"updatetext\"",
            "\"use\"",
            "\"user\"",
            "\"values\"",
            "\"varying\"",
            "\"view\"",
            "\"waitfor\"",
            "\"when\"",
            "\"where\"",
            "\"while\"",
            "\"with\"",
            "\"writetext\"",
            "\"Disk\"",
            "\"Precision\"",
            "\"External\"",
            "\"Revert\"",
            "\"Pivot\"",
            "\"Unpivot\"",
            "\"TableSample\"",
            "\"Dump\"",
            "\"Load\"",
            "\"Merge\"",
            "\"StopList\"",
            "\"SemanticKeyPhraseTable\"",
            "\"SemanticSimilarityTable\"",
            "\"SemanticSimilarityDetailsTable\"",
            "\"TryConvert\"",
            "\"Bang\"",
            "\"PercentSign\"",
            "\"Ampersand\"",
            "\"LeftParenthesis\"",
            "\"RightParenthesis\"",
            "\"LeftCurly\"",
            "\"RightCurly\"",
            "\"Star\"",
            "\"MultiplyEquals\"",
            "\"Plus\"",
            "\"Comma\"",
            "\"Minus\"",
            "\"Dot\"",
            "\"Divide\"",
            "\"Colon\"",
            "\"DoubleColon\"",
            "\"Semicolon\"",
            "\"LessThan\"",
            "\"EqualsSign\"",
            "\"RightOuterJoin\"",
            "\"GreaterThan\"",
            "\"Circumflex\"",
            "\"VerticalLine\"",
            "\"Tilde\"",
            "\"AddEquals\"",
            "\"SubtractEquals\"",
            "\"DivideEquals\"",
            "\"ModEquals\"",
            "\"BitwiseAndEquals\"",
            "\"BitwiseOrEquals\"",
            "\"BitwiseXorEquals\"",
            "\"Go\"",
            "\"Label\"",
            "\"Integer\"",
            "\"Numeric\"",
            "\"Real\"",
            "\"HexLiteral\"",
            "\"Money\"",
            "\"SqlCommandIdentifier\"",
            "\"PseudoColumn\"",
            "\"DollarPartition\"",
            "\"AsciiStringOrQuotedIdentifier\"",
            "\"AsciiStringLiteral\"",
            "\"UnicodeStringLiteral\"",
            "\"Identifier\"",
            "\"QuotedIdentifier\"",
            "\"Variable\"",
            "\"OdbcInitiator\"",
            "\"ProcNameSemicolon\"",
            "\"SingleLineComment\"",
            "\"MultilineComment\"",
            "\"WhiteSpace\""
        };

        public static readonly BitSet tokenSet_0_ = new BitSet(TSql80ParserInternal.mk_tokenSet_0_());

        public static readonly BitSet tokenSet_1_ = new BitSet(TSql80ParserInternal.mk_tokenSet_1_());

        public static readonly BitSet tokenSet_2_ = new BitSet(TSql80ParserInternal.mk_tokenSet_2_());

        public static readonly BitSet tokenSet_3_ = new BitSet(TSql80ParserInternal.mk_tokenSet_3_());

        public static readonly BitSet tokenSet_4_ = new BitSet(TSql80ParserInternal.mk_tokenSet_4_());

        public static readonly BitSet tokenSet_5_ = new BitSet(TSql80ParserInternal.mk_tokenSet_5_());

        public static readonly BitSet tokenSet_6_ = new BitSet(TSql80ParserInternal.mk_tokenSet_6_());

        public static readonly BitSet tokenSet_7_ = new BitSet(TSql80ParserInternal.mk_tokenSet_7_());

        public static readonly BitSet tokenSet_8_ = new BitSet(TSql80ParserInternal.mk_tokenSet_8_());

        public static readonly BitSet tokenSet_9_ = new BitSet(TSql80ParserInternal.mk_tokenSet_9_());

        public static readonly BitSet tokenSet_10_ = new BitSet(TSql80ParserInternal.mk_tokenSet_10_());

        public static readonly BitSet tokenSet_11_ = new BitSet(TSql80ParserInternal.mk_tokenSet_11_());

        public static readonly BitSet tokenSet_12_ = new BitSet(TSql80ParserInternal.mk_tokenSet_12_());

        public static readonly BitSet tokenSet_13_ = new BitSet(TSql80ParserInternal.mk_tokenSet_13_());

        public static readonly BitSet tokenSet_14_ = new BitSet(TSql80ParserInternal.mk_tokenSet_14_());

        public static readonly BitSet tokenSet_15_ = new BitSet(TSql80ParserInternal.mk_tokenSet_15_());

        public static readonly BitSet tokenSet_16_ = new BitSet(TSql80ParserInternal.mk_tokenSet_16_());

        public static readonly BitSet tokenSet_17_ = new BitSet(TSql80ParserInternal.mk_tokenSet_17_());

        public static readonly BitSet tokenSet_18_ = new BitSet(TSql80ParserInternal.mk_tokenSet_18_());

        public static readonly BitSet tokenSet_19_ = new BitSet(TSql80ParserInternal.mk_tokenSet_19_());

        public static readonly BitSet tokenSet_20_ = new BitSet(TSql80ParserInternal.mk_tokenSet_20_());

        public static readonly BitSet tokenSet_21_ = new BitSet(TSql80ParserInternal.mk_tokenSet_21_());

        public static readonly BitSet tokenSet_22_ = new BitSet(TSql80ParserInternal.mk_tokenSet_22_());

        public static readonly BitSet tokenSet_23_ = new BitSet(TSql80ParserInternal.mk_tokenSet_23_());

        public static readonly BitSet tokenSet_24_ = new BitSet(TSql80ParserInternal.mk_tokenSet_24_());

        public static readonly BitSet tokenSet_25_ = new BitSet(TSql80ParserInternal.mk_tokenSet_25_());

        public static readonly BitSet tokenSet_26_ = new BitSet(TSql80ParserInternal.mk_tokenSet_26_());

        public static readonly BitSet tokenSet_27_ = new BitSet(TSql80ParserInternal.mk_tokenSet_27_());

        public static readonly BitSet tokenSet_28_ = new BitSet(TSql80ParserInternal.mk_tokenSet_28_());

        public static readonly BitSet tokenSet_29_ = new BitSet(TSql80ParserInternal.mk_tokenSet_29_());

        public static readonly BitSet tokenSet_30_ = new BitSet(TSql80ParserInternal.mk_tokenSet_30_());

        public static readonly BitSet tokenSet_31_ = new BitSet(TSql80ParserInternal.mk_tokenSet_31_());

        public static readonly BitSet tokenSet_32_ = new BitSet(TSql80ParserInternal.mk_tokenSet_32_());

        public static readonly BitSet tokenSet_33_ = new BitSet(TSql80ParserInternal.mk_tokenSet_33_());

        public static readonly BitSet tokenSet_34_ = new BitSet(TSql80ParserInternal.mk_tokenSet_34_());

        public static readonly BitSet tokenSet_35_ = new BitSet(TSql80ParserInternal.mk_tokenSet_35_());

        public static readonly BitSet tokenSet_36_ = new BitSet(TSql80ParserInternal.mk_tokenSet_36_());

        public static readonly BitSet tokenSet_37_ = new BitSet(TSql80ParserInternal.mk_tokenSet_37_());

        public static readonly BitSet tokenSet_38_ = new BitSet(TSql80ParserInternal.mk_tokenSet_38_());

        public static readonly BitSet tokenSet_39_ = new BitSet(TSql80ParserInternal.mk_tokenSet_39_());

        public static readonly BitSet tokenSet_40_ = new BitSet(TSql80ParserInternal.mk_tokenSet_40_());

        public static readonly BitSet tokenSet_41_ = new BitSet(TSql80ParserInternal.mk_tokenSet_41_());

        public static readonly BitSet tokenSet_42_ = new BitSet(TSql80ParserInternal.mk_tokenSet_42_());

        public static readonly BitSet tokenSet_43_ = new BitSet(TSql80ParserInternal.mk_tokenSet_43_());

        public static readonly BitSet tokenSet_44_ = new BitSet(TSql80ParserInternal.mk_tokenSet_44_());

        public static readonly BitSet tokenSet_45_ = new BitSet(TSql80ParserInternal.mk_tokenSet_45_());

        public static readonly BitSet tokenSet_46_ = new BitSet(TSql80ParserInternal.mk_tokenSet_46_());

        public static readonly BitSet tokenSet_47_ = new BitSet(TSql80ParserInternal.mk_tokenSet_47_());

        public static readonly BitSet tokenSet_48_ = new BitSet(TSql80ParserInternal.mk_tokenSet_48_());

        public static readonly BitSet tokenSet_49_ = new BitSet(TSql80ParserInternal.mk_tokenSet_49_());

        public static readonly BitSet tokenSet_50_ = new BitSet(TSql80ParserInternal.mk_tokenSet_50_());

        public static readonly BitSet tokenSet_51_ = new BitSet(TSql80ParserInternal.mk_tokenSet_51_());

        public static readonly BitSet tokenSet_52_ = new BitSet(TSql80ParserInternal.mk_tokenSet_52_());

        public static readonly BitSet tokenSet_53_ = new BitSet(TSql80ParserInternal.mk_tokenSet_53_());

        public static readonly BitSet tokenSet_54_ = new BitSet(TSql80ParserInternal.mk_tokenSet_54_());

        public static readonly BitSet tokenSet_55_ = new BitSet(TSql80ParserInternal.mk_tokenSet_55_());

        public static readonly BitSet tokenSet_56_ = new BitSet(TSql80ParserInternal.mk_tokenSet_56_());

        public static readonly BitSet tokenSet_57_ = new BitSet(TSql80ParserInternal.mk_tokenSet_57_());

        public static readonly BitSet tokenSet_58_ = new BitSet(TSql80ParserInternal.mk_tokenSet_58_());

        public static readonly BitSet tokenSet_59_ = new BitSet(TSql80ParserInternal.mk_tokenSet_59_());

        public static readonly BitSet tokenSet_60_ = new BitSet(TSql80ParserInternal.mk_tokenSet_60_());

        public static readonly BitSet tokenSet_61_ = new BitSet(TSql80ParserInternal.mk_tokenSet_61_());

        public static readonly BitSet tokenSet_62_ = new BitSet(TSql80ParserInternal.mk_tokenSet_62_());

        public static readonly BitSet tokenSet_63_ = new BitSet(TSql80ParserInternal.mk_tokenSet_63_());

        public static readonly BitSet tokenSet_64_ = new BitSet(TSql80ParserInternal.mk_tokenSet_64_());

        public static readonly BitSet tokenSet_65_ = new BitSet(TSql80ParserInternal.mk_tokenSet_65_());

        public static readonly BitSet tokenSet_66_ = new BitSet(TSql80ParserInternal.mk_tokenSet_66_());

        public static readonly BitSet tokenSet_67_ = new BitSet(TSql80ParserInternal.mk_tokenSet_67_());

        public static readonly BitSet tokenSet_68_ = new BitSet(TSql80ParserInternal.mk_tokenSet_68_());

        public static readonly BitSet tokenSet_69_ = new BitSet(TSql80ParserInternal.mk_tokenSet_69_());

        public static readonly BitSet tokenSet_70_ = new BitSet(TSql80ParserInternal.mk_tokenSet_70_());

        public static readonly BitSet tokenSet_71_ = new BitSet(TSql80ParserInternal.mk_tokenSet_71_());

        public static readonly BitSet tokenSet_72_ = new BitSet(TSql80ParserInternal.mk_tokenSet_72_());

        public static readonly BitSet tokenSet_73_ = new BitSet(TSql80ParserInternal.mk_tokenSet_73_());

        public static readonly BitSet tokenSet_74_ = new BitSet(TSql80ParserInternal.mk_tokenSet_74_());

        public static readonly BitSet tokenSet_75_ = new BitSet(TSql80ParserInternal.mk_tokenSet_75_());

        public static readonly BitSet tokenSet_76_ = new BitSet(TSql80ParserInternal.mk_tokenSet_76_());

        public static readonly BitSet tokenSet_77_ = new BitSet(TSql80ParserInternal.mk_tokenSet_77_());

        public static readonly BitSet tokenSet_78_ = new BitSet(TSql80ParserInternal.mk_tokenSet_78_());

        public static readonly BitSet tokenSet_79_ = new BitSet(TSql80ParserInternal.mk_tokenSet_79_());

        public static readonly BitSet tokenSet_80_ = new BitSet(TSql80ParserInternal.mk_tokenSet_80_());

        public static readonly BitSet tokenSet_81_ = new BitSet(TSql80ParserInternal.mk_tokenSet_81_());

        public static readonly BitSet tokenSet_82_ = new BitSet(TSql80ParserInternal.mk_tokenSet_82_());

        public static readonly BitSet tokenSet_83_ = new BitSet(TSql80ParserInternal.mk_tokenSet_83_());

        public static readonly BitSet tokenSet_84_ = new BitSet(TSql80ParserInternal.mk_tokenSet_84_());

        public static readonly BitSet tokenSet_85_ = new BitSet(TSql80ParserInternal.mk_tokenSet_85_());

        public static readonly BitSet tokenSet_86_ = new BitSet(TSql80ParserInternal.mk_tokenSet_86_());

        public static readonly BitSet tokenSet_87_ = new BitSet(TSql80ParserInternal.mk_tokenSet_87_());

        public TSql80ParserInternal(bool initialQuotedIdentifiersOn)
            : base(initialQuotedIdentifiersOn) {
            this.initialize();
        }

        protected void initialize() {
            base.tokenNames = TSql80ParserInternal.tokenNames_;
        }

        protected TSql80ParserInternal(TokenBuffer tokenBuf, int k)
            : base(tokenBuf, k) {
            this.initialize();
        }

        public TSql80ParserInternal(TokenBuffer tokenBuf)
            : this(tokenBuf, 2) {
        }

        protected TSql80ParserInternal(TokenStream lexer, int k)
            : base(lexer, k) {
            this.initialize();
        }

        public TSql80ParserInternal(TokenStream lexer)
            : this(lexer, 2) {
        }

        public TSql80ParserInternal(ParserSharedInputState state)
            : base(state, 2) {
            this.initialize();
        }

        public ChildObjectName entryPointChildObjectName() {
            ChildObjectName childObjectName = null;
            childObjectName = this.childObjectNameWithThreePrefixes();
            this.match(1);
            return childObjectName;
        }

        public ChildObjectName childObjectNameWithThreePrefixes() {
            ChildObjectName childObjectName = base.FragmentFactory.CreateFragment<ChildObjectName>();
            List<Identifier> otherCollection = this.identifierList(4);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(childObjectName, childObjectName.Identifiers, otherCollection);
            }
            return childObjectName;
        }

        public SchemaObjectName entryPointSchemaObjectName() {
            SchemaObjectName schemaObjectName = null;
            schemaObjectName = this.schemaObjectFourPartName();
            this.match(1);
            return schemaObjectName;
        }

        public SchemaObjectName schemaObjectFourPartName() {
            SchemaObjectName schemaObjectName = base.FragmentFactory.CreateFragment<SchemaObjectName>();
            List<Identifier> otherCollection = this.identifierList(4);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(schemaObjectName, schemaObjectName.Identifiers, otherCollection);
            }
            return schemaObjectName;
        }

        public DataTypeReference entryPointScalarDataType() {
            DataTypeReference dataTypeReference = null;
            dataTypeReference = this.scalarDataType();
            this.match(1);
            return dataTypeReference;
        }

        public DataTypeReference scalarDataType() {
            DataTypeReference dataTypeReference = null;
            SchemaObjectName schemaObjectName = null;
            SqlDataTypeOption sqlDataTypeOption = SqlDataTypeOption.None;
            switch (this.LA(1)) {
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            schemaObjectName = base.FragmentFactory.CreateFragment<SchemaObjectName>();
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(schemaObjectName, schemaObjectName.Identifiers, identifier);
                            sqlDataTypeOption = TSql80ParserBaseInternal.ParseDataType(identifier.Value);
                        }
                        if (TSql80ParserInternal.tokenSet_0_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_1_.member(this.LA(2)) && sqlDataTypeOption != 0) {
                            return this.sqlDataTypeWithoutNational(schemaObjectName, sqlDataTypeOption);
                        }
                        if (TSql80ParserInternal.tokenSet_2_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_1_.member(this.LA(2))) {
                            return this.userDataType(schemaObjectName);
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 53:
                    return this.doubleDataType();
                case 96:
                    return this.sqlDataTypeWithNational();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ScalarExpression entryPointExpression() {
            ScalarExpression scalarExpression = null;
            scalarExpression = this.expression();
            this.match(1);
            return scalarExpression;
        }

        public ScalarExpression expression() {
            ScalarExpression scalarExpression = null;
            return this.expressionWithFlags(ExpressionFlags.None);
        }

        public BooleanExpression entryPointBooleanExpression() {
            BooleanExpression booleanExpression = null;
            booleanExpression = this.booleanExpression();
            this.match(1);
            return booleanExpression;
        }

        public BooleanExpression booleanExpression() {
            BooleanExpression booleanExpression = null;
            return this.booleanExpressionWithFlags(ExpressionFlags.None);
        }

        public StatementList entryPointStatementList() {
            StatementList statementList = null;
            bool flag = false;
            statementList = this.statementList(ref flag);
            if (base.inputState.guessing == 0 && flag) {
                statementList = null;
            }
            this.match(1);
            return statementList;
        }

        public StatementList statementList(ref bool vParseErrorOccurred) {
            StatementList statementList = base.FragmentFactory.CreateFragment<StatementList>();
            int num = 0;
            while (true) {
                if (!TSql80ParserInternal.tokenSet_3_.member(this.LA(1))) {
                    break;
                }
                TSqlStatement tSqlStatement = this.statementOptSemi();
                if (base.inputState.guessing == 0) {
                    if (tSqlStatement != null) {
                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(statementList, statementList.Statements, tSqlStatement);
                    } else {
                        vParseErrorOccurred = true;
                    }
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return statementList;
        }

        public SelectStatement entryPointSubqueryExpressionWithOptionalCTE() {
            SelectStatement selectStatement = null;
            selectStatement = this.subqueryExpressionAsStatement();
            this.match(1);
            return selectStatement;
        }

        public SelectStatement subqueryExpressionAsStatement() {
            SelectStatement selectStatement = base.FragmentFactory.CreateFragment<SelectStatement>();
            QueryExpression queryExpression = this.subqueryExpression();
            if (base.inputState.guessing == 0) {
                selectStatement.QueryExpression = queryExpression;
            }
            return selectStatement;
        }

        public TSqlFragment entryPointConstantOrIdentifier() {
            TSqlFragment tSqlFragment = null;
            tSqlFragment = this.possibleNegativeConstantOrIdentifier();
            this.match(1);
            return tSqlFragment;
        }

        public ScalarExpression possibleNegativeConstantOrIdentifier() {
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 234:
                    return this.possibleNegativeConstant();
                case 232:
                case 233:
                    return this.identifierLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TSqlFragment entryPointConstantOrIdentifierWithDefault() {
            TSqlFragment tSqlFragment = null;
            tSqlFragment = this.possibleNegativeConstantOrIdentifierWithDefault();
            this.match(1);
            return tSqlFragment;
        }

        public ScalarExpression possibleNegativeConstantOrIdentifierWithDefault() {
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                    return this.possibleNegativeConstantOrIdentifier();
                case 47:
                    return this.defaultLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TSqlScript script() {
            TSqlScript tSqlScript = base.FragmentFactory.CreateFragment<TSqlScript>();
            IToken token = null;
            if (tSqlScript.ScriptTokenStream != null && tSqlScript.ScriptTokenStream.Count > 0) {
                tSqlScript.UpdateTokenInfo(0, tSqlScript.ScriptTokenStream.Count - 1);
            }
            TSqlBatch tSqlBatch = this.batch();
            if (base.inputState.guessing == 0 && tSqlBatch != null) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(tSqlScript, tSqlScript.Batches, tSqlBatch);
            }
            while (true) {
                if (this.LA(1) != 219) {
                    break;
                }
                this.match(219);
                if (base.inputState.guessing == 0) {
                    base.ResetQuotedIdentifiersSettingToInitial();
                    base.ThrowPartialAstIfPhaseOne(null);
                }
                tSqlBatch = this.batch();
                if (base.inputState.guessing == 0 && tSqlBatch != null) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(tSqlScript, tSqlScript.Batches, tSqlBatch);
                }
            }
            token = this.LT(1);
            this.match(1);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSqlScript, token);
            }
            return tSqlScript;
        }

        public TSqlBatch batch() {
            TSqlBatch tSqlBatch = null;
            try {
                bool flag = false;
                if ((this.LA(1) == 6 || this.LA(1) == 35) && TSql80ParserInternal.tokenSet_4_.member(this.LA(2))) {
                    int pos = this.mark();
                    flag = true;
                    base.inputState.guessing++;
                    try {
                        switch (this.LA(1)) {
                            case 35:
                                this.match(35);
                                switch (this.LA(1)) {
                                    case 120:
                                        this.match(120);
                                        break;
                                    case 121:
                                        this.match(121);
                                        break;
                                    case 155:
                                        this.match(155);
                                        break;
                                    case 47:
                                        this.match(47);
                                        break;
                                    case 137:
                                        this.match(137);
                                        break;
                                    case 166:
                                        this.match(166);
                                        break;
                                    case 73:
                                        this.match(73);
                                        break;
                                    case 139:
                                        this.match(139);
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                                break;
                            case 6:
                                this.match(6);
                                switch (this.LA(1)) {
                                    case 120:
                                        this.match(120);
                                        break;
                                    case 121:
                                        this.match(121);
                                        break;
                                    case 155:
                                        this.match(155);
                                        break;
                                    case 166:
                                        this.match(166);
                                        break;
                                    case 73:
                                        this.match(73);
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                        }
                    } catch (RecognitionException) {
                        flag = false;
                    }
                    this.rewind(pos);
                    base.inputState.guessing--;
                }
                if (flag) {
                    TSqlStatement tSqlStatement = this.lastStatement();
                    if (base.inputState.guessing == 0) {
                        if (tSqlStatement != null) {
                            if (tSqlBatch == null) {
                                tSqlBatch = base.FragmentFactory.CreateFragment<TSqlBatch>();
                            }
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(tSqlBatch, tSqlBatch.Statements, tSqlStatement);
                            return tSqlBatch;
                        }
                        return tSqlBatch;
                    }
                    return tSqlBatch;
                }
                if (TSql80ParserInternal.tokenSet_5_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_6_.member(this.LA(2))) {
                    TSqlStatement tSqlStatement = this.optSimpleExecute();
                    if (base.inputState.guessing == 0 && tSqlStatement != null) {
                        base.ThrowPartialAstIfPhaseOne(tSqlStatement);
                        if (tSqlBatch == null) {
                            tSqlBatch = base.FragmentFactory.CreateFragment<TSqlBatch>();
                        }
                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(tSqlBatch, tSqlBatch.Statements, tSqlStatement);
                    }
                    while (true) {
                        if (!TSql80ParserInternal.tokenSet_3_.member(this.LA(1))) {
                            break;
                        }
                        tSqlStatement = this.statementOptSemi();
                        if (base.inputState.guessing == 0 && tSqlStatement != null) {
                            if (tSqlBatch == null) {
                                tSqlBatch = base.FragmentFactory.CreateFragment<TSqlBatch>();
                            }
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(tSqlBatch, tSqlBatch.Statements, tSqlStatement);
                        }
                    }
                    return tSqlBatch;
                }
                throw new NoViableAltException(this.LT(1), this.getFilename());
            } catch (TSqlParseErrorException ex2) {
                if (base.inputState.guessing == 0) {
                    if (!ex2.DoNotLog) {
                        base.AddParseError(ex2.ParseError);
                    }
                    base.RecoverAtBatchLevel();
                    return tSqlBatch;
                }
                throw;
            } catch (NoViableAltException ex3) {
                if (base.inputState.guessing == 0) {
                    ParseError faultTolerantUnexpectedTokenError = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex3.token, ex3, base._tokenSource.LastToken.Offset);
                    base.AddParseError(faultTolerantUnexpectedTokenError);
                    base.RecoverAtBatchLevel();
                    return tSqlBatch;
                }
                throw;
            } catch (MismatchedTokenException ex4) {
                if (base.inputState.guessing == 0) {
                    ParseError faultTolerantUnexpectedTokenError2 = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex4.token, ex4, base._tokenSource.LastToken.Offset);
                    base.AddParseError(faultTolerantUnexpectedTokenError2);
                    base.RecoverAtBatchLevel();
                    return tSqlBatch;
                }
                throw;
            } catch (RecognitionException) {
                if (base.inputState.guessing == 0) {
                    ParseError unexpectedTokenError = base.GetUnexpectedTokenError();
                    base.AddParseError(unexpectedTokenError);
                    base.RecoverAtBatchLevel();
                    return tSqlBatch;
                }
                throw;
            } catch (TokenStreamRecognitionException exception) {
                if (base.inputState.guessing == 0) {
                    ParseError parseError = TSql80ParserBaseInternal.ProcessTokenStreamRecognitionException(exception, base._tokenSource.LastToken.Offset);
                    base.AddParseError(parseError);
                    base.RecoverAtBatchLevel();
                    return tSqlBatch;
                }
                throw;
            } catch (ANTLRException exception2) {
                if (base.inputState.guessing == 0) {
                    base.CreateInternalError("batch", exception2);
                    return tSqlBatch;
                }
                throw;
            }
        }

        public TSqlStatement lastStatement() {
            TSqlStatement tSqlStatement = null;
            if (this.LA(1) == 35 && (this.LA(2) == 120 || this.LA(2) == 121)) {
                return this.createProcedureStatement();
            }
            if (this.LA(1) == 6 && (this.LA(2) == 120 || this.LA(2) == 121)) {
                return this.alterProcedureStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 155) {
                return this.createTriggerStatement();
            }
            if (this.LA(1) == 6 && this.LA(2) == 155) {
                return this.alterTriggerStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 47) {
                return this.createDefaultStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 137) {
                return this.createRuleStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 166) {
                return this.createViewStatement();
            }
            if (this.LA(1) == 6 && this.LA(2) == 166) {
                return this.alterViewStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 73) {
                return this.createFunctionStatement();
            }
            if (this.LA(1) == 6 && this.LA(2) == 73) {
                return this.alterFunctionStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 139) {
                return this.createSchemaStatement();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ExecuteStatement optSimpleExecute() {
            ExecuteStatement executeStatement = null;
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_02b0;
                }
            } else {
                switch (num) {
                    case 200:
                    case 232:
                    case 233:
                    case 234: {
                            ExecutableProcedureReference executableEntity = this.execProc();
                            if (base.inputState.guessing == 0) {
                                executeStatement = base.FragmentFactory.CreateFragment<ExecuteStatement>();
                                ExecuteSpecification executeSpecification = base.FragmentFactory.CreateFragment<ExecuteSpecification>();
                                executeSpecification.ExecutableEntity = executableEntity;
                                executeStatement.ExecuteSpecification = executeSpecification;
                            }
                            this.optSingleSemicolon(executeStatement);
                            goto IL_02b0;
                        }
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 219:
                    case 220:
                        goto IL_02b0;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02b0:
            return executeStatement;
        }

        public TSqlStatement statementOptSemi() {
            TSqlStatement tSqlStatement = null;
            tSqlStatement = this.statement();
            this.optSingleSemicolon(tSqlStatement);
            return tSqlStatement;
        }

        public TSqlStatement statement() {
            TSqlStatement result = null;
            int line = this.LT(1).getLine();
            int column = this.LT(1).getColumn();
            try {
                switch (this.LA(1)) {
                    case 46:
                        result = this.declareStatements();
                        return result;
                    case 142:
                        result = this.setStatements();
                        return result;
                    case 13:
                        result = this.beginStatements();
                        return result;
                    case 15:
                        result = this.breakStatement();
                        return result;
                    case 33:
                        result = this.continueStatement();
                        return result;
                    case 82:
                        result = this.ifStatement();
                        return result;
                    case 170:
                        result = this.whileStatement();
                        return result;
                    case 220:
                        result = this.labelStatement();
                        return result;
                    case 12:
                    case 180:
                        result = this.backupStatement();
                        return result;
                    case 129:
                    case 181:
                        result = this.restoreStatement();
                        return result;
                    case 74:
                        result = this.gotoStatement();
                        return result;
                    case 138:
                        result = this.saveTransactionStatement();
                        return result;
                    case 134:
                        result = this.rollbackTransactionStatement();
                        return result;
                    case 28:
                        result = this.commitTransactionStatement();
                        return result;
                    case 60:
                    case 61:
                        result = this.executeStatement();
                        return result;
                    case 140:
                    case 191:
                        result = this.select();
                        return result;
                    case 48:
                        result = this.deleteStatement();
                        return result;
                    case 123:
                        result = this.raiseErrorStatements();
                        return result;
                    case 119:
                        result = this.printStatement();
                        return result;
                    case 167:
                        result = this.waitForStatement();
                        return result;
                    case 125:
                        result = this.readTextStatement();
                        return result;
                    case 161:
                        result = this.updateTextStatement();
                        return result;
                    case 172:
                        result = this.writeTextStatement();
                        return result;
                    case 95:
                        result = this.lineNoStatement();
                        return result;
                    case 162:
                        result = this.useStatement();
                        return result;
                    case 92:
                        result = this.killStatement();
                        return result;
                    case 17:
                        result = this.bulkInsertStatement();
                        return result;
                    case 22:
                        result = this.checkpointStatement();
                        return result;
                    case 126:
                        result = this.reconfigureStatement();
                        return result;
                    case 144:
                        result = this.shutdownStatement();
                        return result;
                    case 143:
                        result = this.setUserStatement();
                        return result;
                    case 156:
                        result = this.truncateTableStatement();
                        return result;
                    case 75:
                        result = this.grantStatement80();
                        return result;
                    case 49:
                        result = this.denyStatement80();
                        return result;
                    case 132:
                        result = this.revokeStatement80();
                        return result;
                    case 131:
                        result = this.returnStatement();
                        return result;
                    case 106:
                        result = this.openCursorStatement();
                        return result;
                    case 23:
                        result = this.closeCursorStatement();
                        return result;
                    case 45:
                        result = this.deallocateCursorStatement();
                        return result;
                    case 64:
                        result = this.fetchCursorStatement();
                        return result;
                    case 54:
                        result = this.dropStatements();
                        return result;
                    case 44:
                        result = this.dbccStatement();
                        return result;
                    case 176:
                        result = this.revertStatement();
                        return result;
                    case 173:
                        result = this.diskStatement();
                        return result;
                    default:
                        if (this.LA(1) == 35 && this.LA(2) == 148) {
                            result = this.createTableStatement();
                            return result;
                        }
                        if (this.LA(1) == 6 && this.LA(2) == 148) {
                            result = this.alterTableStatement();
                            return result;
                        }
                        if (this.LA(1) == 35 && TSql80ParserInternal.tokenSet_7_.member(this.LA(2))) {
                            result = this.createIndexStatement();
                            return result;
                        }
                        if (this.LA(1) == 35 && this.LA(2) == 146) {
                            result = this.createStatisticsStatement();
                            return result;
                        }
                        if (this.LA(1) == 160 && this.LA(2) == 146) {
                            result = this.updateStatisticsStatement();
                            return result;
                        }
                        if (this.LA(1) == 6 && this.LA(2) == 43) {
                            result = this.alterDatabaseStatements();
                            return result;
                        }
                        if (this.LA(1) == 86 && TSql80ParserInternal.tokenSet_8_.member(this.LA(2))) {
                            result = this.insertStatement();
                            return result;
                        }
                        if (this.LA(1) == 160 && TSql80ParserInternal.tokenSet_9_.member(this.LA(2))) {
                            result = this.updateStatement();
                            return result;
                        }
                        if (this.LA(1) == 35 && this.LA(2) == 43) {
                            result = this.createDatabaseStatement();
                            return result;
                        }
                        if (this.LA(1) == 86 && this.LA(2) == 17) {
                            result = this.insertBulkStatement();
                            return result;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
            } catch (TSqlParseErrorException ex) {
                if (base.inputState.guessing == 0) {
                    if (!ex.DoNotLog) {
                        base.AddParseError(ex.ParseError);
                    }
                    base.RecoverAtStatementLevel(line, column);
                    return result;
                }
                throw;
            } catch (NoViableAltException ex2) {
                if (base.inputState.guessing == 0) {
                    ParseError faultTolerantUnexpectedTokenError = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex2.token, ex2, base._tokenSource.LastToken.Offset);
                    base.AddParseError(faultTolerantUnexpectedTokenError);
                    base.RecoverAtStatementLevel(line, column);
                    return result;
                }
                throw;
            } catch (MismatchedTokenException ex3) {
                if (base.inputState.guessing == 0) {
                    ParseError faultTolerantUnexpectedTokenError2 = TSql80ParserBaseInternal.GetFaultTolerantUnexpectedTokenError(ex3.token, ex3, base._tokenSource.LastToken.Offset);
                    base.AddParseError(faultTolerantUnexpectedTokenError2);
                    base.RecoverAtStatementLevel(line, column);
                    return result;
                }
                throw;
            } catch (RecognitionException) {
                if (base.inputState.guessing == 0) {
                    ParseError unexpectedTokenError = base.GetUnexpectedTokenError();
                    base.AddParseError(unexpectedTokenError);
                    base.RecoverAtStatementLevel(line, column);
                    return result;
                }
                throw;
            } catch (TokenStreamRecognitionException exception) {
                if (base.inputState.guessing == 0) {
                    ParseError parseError = TSql80ParserBaseInternal.ProcessTokenStreamRecognitionException(exception, base._tokenSource.LastToken.Offset);
                    base.AddParseError(parseError);
                    base.RecoverAtStatementLevel(line, column);
                    return result;
                }
                throw;
            } catch (ANTLRException exception2) {
                if (base.inputState.guessing == 0) {
                    base.CreateInternalError("statement", exception2);
                    return result;
                }
                throw;
            }
        }

        public void optSingleSemicolon(TSqlStatement vParent) {
            IToken token = null;
            if (this.LA(1) == 204 && TSql80ParserInternal.tokenSet_10_.member(this.LA(2))) {
                token = this.LT(1);
                this.match(204);
                if (base.inputState.guessing == 0 && vParent != null) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                }
                return;
            }
            if (TSql80ParserInternal.tokenSet_10_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ExecutableProcedureReference execProc() {
            ExecutableProcedureReference executableProcedureReference = base.FragmentFactory.CreateFragment<ExecutableProcedureReference>();
            ProcedureReferenceName procedureReference;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233:
                    procedureReference = this.procObjectReference();
                    break;
                case 234:
                    procedureReference = this.varObjectReference();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                executableProcedureReference.ProcedureReference = procedureReference;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 47:
                        break;
                    default:
                        goto IL_0326;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0339;
                }
            } else {
                switch (num) {
                    case 100:
                    case 193:
                    case 199:
                    case 221:
                    case 222:
                    case 223:
                    case 224:
                    case 225:
                    case 230:
                    case 231:
                    case 232:
                    case 233:
                    case 234:
                        break;
                    default:
                        goto IL_0326;
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0339;
                }
            }
            this.setParamList(executableProcedureReference);
            goto IL_0339;
            IL_0339:
            return executableProcedureReference;
            IL_0326:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public CreateTableStatement createTableStatement() {
            CreateTableStatement createTableStatement = base.FragmentFactory.CreateFragment<CreateTableStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(35);
            this.match(148);
            SchemaObjectName schemaObjectName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createTableStatement, token);
                createTableStatement.SchemaObjectName = schemaObjectName;
                base.ThrowPartialAstIfPhaseOne(createTableStatement);
            }
            this.match(191);
            TableDefinition definition = this.tableDefinitionCreateTable();
            if (base.inputState.guessing == 0) {
                createTableStatement.Definition = definition;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createTableStatement, token2);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_035b;
                }
            } else {
                switch (num) {
                    case 105: {
                            this.match(105);
                            FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = this.filegroupOrPartitionScheme();
                            if (base.inputState.guessing == 0) {
                                createTableStatement.OnFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
                            }
                            goto IL_035b;
                        }
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                    case 232:
                        goto IL_035b;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_061a:
            return createTableStatement;
            IL_035b:
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_061a;
                }
            } else {
                switch (num2) {
                    case 232: {
                            token3 = this.LT(1);
                            this.match(232);
                            IdentifierOrValueExpression textImageOn = this.stringOrIdentifier();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.Match(token3, "TEXTIMAGE_ON");
                                createTableStatement.TextImageOn = textImageOn;
                            }
                            goto IL_061a;
                        }
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_061a;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public AlterTableStatement alterTableStatement() {
            AlterTableStatement alterTableStatement = null;
            IToken token = null;
            SchemaObjectName schemaObjectName = null;
            ConstraintEnforcement vExistingRowsCheck = ConstraintEnforcement.NotSpecified;
            try {
                token = this.LT(1);
                this.match(6);
                this.match(148);
                schemaObjectName = this.schemaObjectThreePartName();
                switch (this.LA(1)) {
                    case 6:
                        alterTableStatement = this.alterTableAlterColumnStatement();
                        break;
                    case 232:
                        alterTableStatement = this.alterTableTriggerModificationStatement();
                        break;
                    case 54:
                        alterTableStatement = this.alterTableDropTableElementStatement();
                        break;
                    case 4:
                    case 21:
                    case 97:
                    case 171:
                        switch (this.LA(1)) {
                            case 171:
                                this.match(171);
                                vExistingRowsCheck = this.constraintEnforcement();
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 4:
                            case 21:
                            case 97:
                                break;
                        }
                        switch (this.LA(1)) {
                            case 4:
                                alterTableStatement = this.alterTableAddTableElementStatement(vExistingRowsCheck);
                                break;
                            case 21:
                            case 97:
                                alterTableStatement = this.alterTableConstraintModificationStatement(vExistingRowsCheck);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(alterTableStatement, token);
                    alterTableStatement.SchemaObjectName = schemaObjectName;
                    return alterTableStatement;
                }
                return alterTableStatement;
            } catch (PhaseOnePartialAstException ex) {
                if (base.inputState.guessing == 0) {
                    AlterTableStatement alterTableStatement2 = ex.Statement as AlterTableStatement;
                    TSql80ParserBaseInternal.UpdateTokenInfo(alterTableStatement2, token);
                    alterTableStatement2.SchemaObjectName = schemaObjectName;
                    throw;
                }
                throw;
            }
        }

        public CreateIndexStatement createIndexStatement() {
            CreateIndexStatement createIndexStatement = base.FragmentFactory.CreateFragment<CreateIndexStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createIndexStatement, token);
            }
            switch (this.LA(1)) {
                case 159:
                    this.match(159);
                    if (base.inputState.guessing == 0) {
                        createIndexStatement.Unique = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 24:
                case 84:
                case 98:
                    break;
            }
            switch (this.LA(1)) {
                case 24:
                    this.match(24);
                    if (base.inputState.guessing == 0) {
                        createIndexStatement.Clustered = true;
                    }
                    break;
                case 98:
                    this.match(98);
                    if (base.inputState.guessing == 0) {
                        createIndexStatement.Clustered = false;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 84:
                    break;
            }
            this.match(84);
            Identifier name = this.identifier();
            if (base.inputState.guessing == 0) {
                createIndexStatement.Name = name;
            }
            this.match(105);
            SchemaObjectName onName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                createIndexStatement.OnName = onName;
                base.ThrowPartialAstIfPhaseOne(createIndexStatement);
            }
            this.match(191);
            ColumnWithSortOrder item = this.columnWithSortOrder();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(createIndexStatement, createIndexStatement.Columns, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.columnWithSortOrder();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(createIndexStatement, createIndexStatement.Columns, item);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createIndexStatement, token2);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0494;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        this.indexLegacyOptionList(createIndexStatement);
                        if (base.inputState.guessing == 0) {
                            createIndexStatement.Translated80SyntaxTo90 = true;
                        }
                        goto IL_0494;
                    case 92:
                    case 95:
                    case 105:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0494;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_073c:
            return createIndexStatement;
            IL_0494:
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_073c;
                }
            } else {
                switch (num2) {
                    case 105: {
                            this.match(105);
                            FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = this.filegroupOrPartitionScheme();
                            if (base.inputState.guessing == 0) {
                                createIndexStatement.OnFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
                            }
                            goto IL_073c;
                        }
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_073c;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public TSqlStatement declareStatements() {
            TSqlStatement tSqlStatement = null;
            IToken token = null;
            token = this.LT(1);
            this.match(46);
            bool flag = false;
            if (this.LA(1) == 234 && this.LA(2) == 148) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(234);
                    switch (this.LA(1)) {
                        case 9:
                            this.match(9);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 148:
                            break;
                    }
                    this.match(148);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                DeclareTableVariableBody body = this.declareTableBody(IndexAffectingStatement.DeclareTableVariable);
                if (base.inputState.guessing == 0) {
                    DeclareTableVariableStatement declareTableVariableStatement = base.FragmentFactory.CreateFragment<DeclareTableVariableStatement>();
                    declareTableVariableStatement.Body = body;
                    tSqlStatement = declareTableVariableStatement;
                }
            } else if (this.LA(1) == 234 && TSql80ParserInternal.tokenSet_12_.member(this.LA(2))) {
                tSqlStatement = this.declareVariableStatement();
            } else {
                if (this.LA(1) != 232 && this.LA(1) != 233) {
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                tSqlStatement = this.declareCursorStatement();
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSqlStatement, token);
            }
            return tSqlStatement;
        }

        public TSqlStatement setStatements() {
            TSqlStatement tSqlStatement = null;
            IToken token = null;
            token = this.LT(1);
            this.match(142);
            switch (this.LA(1)) {
                case 234:
                    tSqlStatement = this.setVariableStatement();
                    break;
                case 146:
                    tSqlStatement = this.setStatisticsStatement();
                    break;
                case 135:
                    tSqlStatement = this.setRowcountStatement();
                    break;
                case 104:
                    tSqlStatement = this.setOffsetsStatement();
                    break;
                case 153:
                case 154:
                    tSqlStatement = this.setTransactionIsolationLevelStatement();
                    break;
                case 149:
                    tSqlStatement = this.setTextSizeStatement();
                    break;
                case 80:
                    tSqlStatement = this.setIdentityInsertStatement();
                    break;
                case 57:
                    tSqlStatement = this.setErrorLevelStatement();
                    break;
                default:
                    if (this.LA(1) == 232 && (this.LA(2) == 103 || this.LA(2) == 105 || this.LA(2) == 198) && !base.NextTokenMatches("FIPS_FLAGGER")) {
                        tSqlStatement = this.predicateSetStatement();
                        break;
                    }
                    if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_13_.member(this.LA(2))) {
                        tSqlStatement = this.setCommandStatement();
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSqlStatement, token);
            }
            return tSqlStatement;
        }

        public TSqlStatement beginStatements() {
            TSqlStatement tSqlStatement = null;
            bool flag = false;
            if (this.LA(1) == 13 && (this.LA(2) == 52 || this.LA(2) == 153 || this.LA(2) == 154)) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(13);
                    switch (this.LA(1)) {
                        case 52:
                            this.match(52);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 153:
                        case 154:
                            break;
                    }
                    switch (this.LA(1)) {
                        case 153:
                            this.match(153);
                            break;
                        case 154:
                            this.match(154);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                return this.beginTransactionStatement();
            }
            if (this.LA(1) == 13 && TSql80ParserInternal.tokenSet_3_.member(this.LA(2))) {
                return this.beginEndBlockStatement();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public BreakStatement breakStatement() {
            BreakStatement breakStatement = base.FragmentFactory.CreateFragment<BreakStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(15);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(breakStatement, token);
            }
            return breakStatement;
        }

        public ContinueStatement continueStatement() {
            ContinueStatement continueStatement = base.FragmentFactory.CreateFragment<ContinueStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(33);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(continueStatement, token);
            }
            return continueStatement;
        }

        public IfStatement ifStatement() {
            IfStatement ifStatement = base.FragmentFactory.CreateFragment<IfStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(82);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(ifStatement, token);
            }
            BooleanExpression predicate = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                ifStatement.Predicate = predicate;
            }
            TSqlStatement tSqlStatement = this.statementOptSemi();
            if (base.inputState.guessing == 0) {
                if (tSqlStatement == null) {
                    flag = true;
                } else {
                    ifStatement.ThenStatement = tSqlStatement;
                }
            }
            if (this.LA(1) == 55 && TSql80ParserInternal.tokenSet_3_.member(this.LA(2))) {
                this.match(55);
                tSqlStatement = this.statementOptSemi();
                if (base.inputState.guessing == 0) {
                    if (tSqlStatement == null) {
                        flag = true;
                    } else {
                        ifStatement.ElseStatement = tSqlStatement;
                    }
                }
                goto IL_00f7;
            }
            if (TSql80ParserInternal.tokenSet_10_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_00f7;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00f7:
            if (base.inputState.guessing == 0 && flag) {
                ifStatement = null;
            }
            return ifStatement;
        }

        public WhileStatement whileStatement() {
            WhileStatement whileStatement = base.FragmentFactory.CreateFragment<WhileStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(170);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(whileStatement, token);
            }
            BooleanExpression predicate = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                whileStatement.Predicate = predicate;
            }
            TSqlStatement tSqlStatement = this.statementOptSemi();
            if (base.inputState.guessing == 0) {
                if (tSqlStatement == null) {
                    whileStatement = null;
                } else {
                    whileStatement.Statement = tSqlStatement;
                }
            }
            return whileStatement;
        }

        public LabelStatement labelStatement() {
            LabelStatement labelStatement = base.FragmentFactory.CreateFragment<LabelStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(220);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(labelStatement, token);
                labelStatement.Value = token.getText();
            }
            return labelStatement;
        }

        public BackupStatement backupStatement() {
            IToken token = this.backupStart();
            BackupStatement backupStatement = this.backupMain();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(backupStatement, token);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02a2;
                }
            } else {
                switch (num) {
                    case 151:
                        this.match(151);
                        this.devList(backupStatement, backupStatement.Devices);
                        goto IL_02a2;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02a2;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0506:
            return backupStatement;
            IL_02a2:
            int num2 = this.LA(1);
            if (num2 <= 86) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0506;
                }
            } else {
                switch (num2) {
                    case 171:
                        this.backupOptions(backupStatement);
                        goto IL_0506;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0506;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public RestoreStatement restoreStatement() {
            RestoreStatement restoreStatement = base.FragmentFactory.CreateFragment<RestoreStatement>();
            IToken token = null;
            IToken token2 = this.restoreStart();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(restoreStatement, token2);
            }
            if (TSql80ParserInternal.tokenSet_14_.member(this.LA(1)) && this.LA(2) >= 232 && this.LA(2) <= 234) {
                this.restoreMain(restoreStatement);
                int num = this.LA(1);
                if (num <= 86) {
                    switch (num) {
                        case 71:
                            this.match(71);
                            this.devList(restoreStatement, restoreStatement.Devices);
                            goto IL_0363;
                        case 1:
                        case 6:
                        case 12:
                        case 13:
                        case 15:
                        case 17:
                        case 22:
                        case 23:
                        case 28:
                        case 33:
                        case 35:
                        case 44:
                        case 45:
                        case 46:
                        case 48:
                        case 49:
                        case 54:
                        case 55:
                        case 56:
                        case 60:
                        case 61:
                        case 64:
                        case 74:
                        case 75:
                        case 82:
                        case 86:
                            goto IL_0363;
                    }
                } else {
                    switch (num) {
                        case 92:
                        case 95:
                        case 106:
                        case 119:
                        case 123:
                        case 125:
                        case 126:
                        case 129:
                        case 131:
                        case 132:
                        case 134:
                        case 138:
                        case 140:
                        case 142:
                        case 143:
                        case 144:
                        case 156:
                        case 160:
                        case 161:
                        case 162:
                        case 167:
                        case 170:
                        case 171:
                        case 172:
                        case 173:
                        case 176:
                        case 180:
                        case 181:
                        case 191:
                        case 204:
                        case 219:
                        case 220:
                            goto IL_0363;
                    }
                }
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (this.LA(1) == 232 && this.LA(2) == 71) {
                token = this.LT(1);
                this.match(232);
                this.match(71);
                this.devList(restoreStatement, restoreStatement.Devices);
                if (base.inputState.guessing == 0) {
                    restoreStatement.Kind = RestoreStatementKindsHelper.Instance.ParseOption(token);
                }
                goto IL_0363;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_05e3:
            return restoreStatement;
            IL_0363:
            int num2 = this.LA(1);
            if (num2 <= 86) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_05e3;
                }
            } else {
                switch (num2) {
                    case 171:
                        this.restoreOptions(restoreStatement);
                        goto IL_05e3;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_05e3;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public GoToStatement gotoStatement() {
            GoToStatement goToStatement = base.FragmentFactory.CreateFragment<GoToStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(74);
            Identifier labelName = this.nonQuotedIdentifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(goToStatement, token);
                goToStatement.LabelName = labelName;
            }
            return goToStatement;
        }

        public SaveTransactionStatement saveTransactionStatement() {
            SaveTransactionStatement saveTransactionStatement = base.FragmentFactory.CreateFragment<SaveTransactionStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(138);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(saveTransactionStatement, token);
            }
            switch (this.LA(1)) {
                case 153:
                    this.match(153);
                    break;
                case 154:
                    this.match(154);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            this.transactionName(saveTransactionStatement);
            return saveTransactionStatement;
        }

        public RollbackTransactionStatement rollbackTransactionStatement() {
            RollbackTransactionStatement rollbackTransactionStatement = base.FragmentFactory.CreateFragment<RollbackTransactionStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            token = this.LT(1);
            this.match(134);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(rollbackTransactionStatement, token);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0638;
                }
                goto IL_0625;
            }
            switch (num) {
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "WORK");
                    }
                    goto IL_0638;
                case 153:
                case 154:
                    break;
                default:
                    goto IL_0625;
                case 95:
                case 106:
                case 119:
                case 123:
                case 125:
                case 126:
                case 129:
                case 131:
                case 132:
                case 134:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 204:
                case 219:
                case 220:
                    goto IL_0638;
            }
            switch (this.LA(1)) {
                case 153:
                    token3 = this.LT(1);
                    this.match(153);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(rollbackTransactionStatement, token3);
                    }
                    break;
                case 154:
                    token4 = this.LT(1);
                    this.match(154);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(rollbackTransactionStatement, token4);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            int num2 = this.LA(1);
            if (num2 <= 95) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                    case 95:
                        goto IL_0638;
                }
            } else {
                switch (num2) {
                    case 199:
                    case 221:
                    case 232:
                    case 233:
                    case 234:
                        this.transactionName(rollbackTransactionStatement);
                        goto IL_0638;
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0638;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0638:
            return rollbackTransactionStatement;
            IL_0625:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public CommitTransactionStatement commitTransactionStatement() {
            CommitTransactionStatement commitTransactionStatement = base.FragmentFactory.CreateFragment<CommitTransactionStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            token = this.LT(1);
            this.match(28);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(commitTransactionStatement, token);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0635;
                }
                goto IL_0622;
            }
            switch (num) {
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "WORK");
                    }
                    goto IL_0635;
                case 153:
                case 154:
                    break;
                default:
                    goto IL_0622;
                case 95:
                case 106:
                case 119:
                case 123:
                case 125:
                case 126:
                case 129:
                case 131:
                case 132:
                case 134:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 204:
                case 219:
                case 220:
                    goto IL_0635;
            }
            switch (this.LA(1)) {
                case 153:
                    token3 = this.LT(1);
                    this.match(153);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(commitTransactionStatement, token3);
                    }
                    break;
                case 154:
                    token4 = this.LT(1);
                    this.match(154);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(commitTransactionStatement, token4);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            int num2 = this.LA(1);
            if (num2 <= 95) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                    case 95:
                        goto IL_0635;
                }
            } else {
                switch (num2) {
                    case 199:
                    case 221:
                    case 232:
                    case 233:
                    case 234:
                        this.transactionName(commitTransactionStatement);
                        goto IL_0635;
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0635;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0635:
            return commitTransactionStatement;
            IL_0622:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public CreateStatisticsStatement createStatisticsStatement() {
            CreateStatisticsStatement createStatisticsStatement = base.FragmentFactory.CreateFragment<CreateStatisticsStatement>();
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            token = this.LT(1);
            this.match(35);
            token2 = this.LT(1);
            this.match(146);
            Identifier name = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createStatisticsStatement, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(createStatisticsStatement, token2);
                createStatisticsStatement.Name = name;
            }
            this.match(105);
            SchemaObjectName onName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                createStatisticsStatement.OnName = onName;
                base.ThrowPartialAstIfPhaseOne(createStatisticsStatement);
            }
            this.identifierColumnList(createStatisticsStatement, createStatisticsStatement.Columns);
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0388;
                }
            } else {
                switch (num) {
                    case 171: {
                            this.match(171);
                            StatisticsOption item = this.createStatisticsStatementWithOption(ref flag);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(createStatisticsStatement, createStatisticsStatement.StatisticsOptions, item);
                            }
                            while (true) {
                                if (this.LA(1) != 198) {
                                    break;
                                }
                                this.match(198);
                                item = this.createStatisticsStatementWithOption(ref flag);
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(createStatisticsStatement, createStatisticsStatement.StatisticsOptions, item);
                                }
                            }
                            goto IL_0388;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0388;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0388:
            return createStatisticsStatement;
        }

        public UpdateStatisticsStatement updateStatisticsStatement() {
            UpdateStatisticsStatement updateStatisticsStatement = base.FragmentFactory.CreateFragment<UpdateStatisticsStatement>();
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            token = this.LT(1);
            this.match(160);
            token2 = this.LT(1);
            this.match(146);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(updateStatisticsStatement, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(updateStatisticsStatement, token2);
            }
            SchemaObjectName schemaObjectName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                updateStatisticsStatement.SchemaObjectName = schemaObjectName;
            }
            bool flag2 = false;
            if (this.LA(1) == 191 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                int pos = this.mark();
                flag2 = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.identifier();
                } catch (RecognitionException) {
                    flag2 = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag2) {
                this.columnNameList(updateStatisticsStatement, updateStatisticsStatement.SubElements);
            } else {
                if (this.LA(1) != 232 && this.LA(1) != 233) {
                    if (TSql80ParserInternal.tokenSet_15_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                        goto IL_017c;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                Identifier item = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(updateStatisticsStatement, updateStatisticsStatement.SubElements, item);
                }
            }
            goto IL_017c;
            IL_046c:
            return updateStatisticsStatement;
            IL_017c:
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_046c;
                }
            } else {
                switch (num) {
                    case 171: {
                            this.match(171);
                            StatisticsOption item2 = this.updateStatisticsStatementWithOption(ref flag);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(updateStatisticsStatement, updateStatisticsStatement.StatisticsOptions, item2);
                            }
                            while (true) {
                                if (this.LA(1) != 198) {
                                    break;
                                }
                                this.match(198);
                                item2 = this.updateStatisticsStatementWithOption(ref flag);
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(updateStatisticsStatement, updateStatisticsStatement.StatisticsOptions, item2);
                                }
                            }
                            goto IL_046c;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_046c;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public AlterDatabaseStatement alterDatabaseStatements() {
            AlterDatabaseStatement alterDatabaseStatement = null;
            IToken token = null;
            Identifier databaseName = null;
            try {
                token = this.LT(1);
                this.match(6);
                this.match(43);
                switch (this.LA(1)) {
                    case 232:
                    case 233:
                        databaseName = this.identifier();
                        break;
                    case 226:
                        databaseName = this.sqlCommandIdentifier();
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                switch (this.LA(1)) {
                    case 4:
                        alterDatabaseStatement = this.alterDbAdd();
                        break;
                    case 142:
                        alterDatabaseStatement = this.alterDbSet();
                        break;
                    case 26:
                        alterDatabaseStatement = this.alterDbCollate();
                        break;
                    default:
                        if (this.LA(1) == 232 && (this.LA(2) == 65 || this.LA(2) == 232) && base.NextTokenMatches("REMOVE")) {
                            alterDatabaseStatement = this.alterDbRemove();
                            break;
                        }
                        if (this.LA(1) == 232 && (this.LA(2) == 65 || this.LA(2) == 232) && base.NextTokenMatches("MODIFY")) {
                            alterDatabaseStatement = this.alterDbModify();
                            break;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                if (base.inputState.guessing == 0) {
                    alterDatabaseStatement.DatabaseName = databaseName;
                    TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseStatement, token);
                    base.ThrowPartialAstIfPhaseOne(alterDatabaseStatement);
                    return alterDatabaseStatement;
                }
                return alterDatabaseStatement;
            } catch (PhaseOnePartialAstException ex) {
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(ex.Statement, token);
                    (ex.Statement as AlterDatabaseStatement).DatabaseName = databaseName;
                    throw;
                }
                throw;
            }
        }

        public ExecuteStatement executeStatement() {
            ExecuteStatement executeStatement = base.FragmentFactory.CreateFragment<ExecuteStatement>();
            ExecuteSpecification executeSpecification = this.executeSpecification();
            if (base.inputState.guessing == 0) {
                executeStatement.ExecuteSpecification = executeSpecification;
                base.ThrowPartialAstIfPhaseOne(executeStatement);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02b7;
                }
            } else {
                switch (num) {
                    case 171: {
                            this.match(171);
                            ExecuteOption item = this.executeOption();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(executeStatement, executeStatement.Options, item);
                            }
                            goto IL_02b7;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02b7;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02b7:
            return executeStatement;
        }

        public SelectStatement select() {
            SelectStatement selectStatement = base.FragmentFactory.CreateFragment<SelectStatement>();
            QueryExpression queryExpression = this.queryExpression(selectStatement);
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_02cf;
                }
            } else {
                switch (num) {
                    case 113: {
                            OrderByClause orderByClause = this.orderByClause();
                            if (base.inputState.guessing == 0) {
                                queryExpression.OrderByClause = orderByClause;
                            }
                            goto IL_02cf;
                        }
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02cf;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02cf:
            while (true) {
                if (this.LA(1) != 29) {
                    break;
                }
                ComputeClause item = this.computeClause();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(selectStatement, selectStatement.ComputeClauses, item);
                }
            }
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 67: {
                            ForClause forClause = this.forClause();
                            if (base.inputState.guessing == 0) {
                                queryExpression.ForClause = forClause;
                            }
                            goto IL_05a4;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_05a4;
                }
            } else {
                switch (num2) {
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_05a4;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_05a4:
            int num3 = this.LA(1);
            if (num3 <= 92) {
                switch (num3) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0834;
                }
            } else {
                switch (num3) {
                    case 111:
                        this.optimizerHints(selectStatement, selectStatement.OptimizerHints);
                        goto IL_0834;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0834;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0834:
            if (base.inputState.guessing == 0) {
                selectStatement.QueryExpression = queryExpression;
            }
            return selectStatement;
        }

        public DeleteStatement deleteStatement() {
            DeleteStatement deleteStatement = base.FragmentFactory.CreateFragment<DeleteStatement>();
            DeleteSpecification deleteSpecification = this.deleteSpecification();
            if (base.inputState.guessing == 0) {
                deleteStatement.DeleteSpecification = deleteSpecification;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0298;
                }
            } else {
                switch (num) {
                    case 111:
                        this.optimizerHints(deleteStatement, deleteStatement.OptimizerHints);
                        goto IL_0298;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0298;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0298:
            return deleteStatement;
        }

        public InsertStatement insertStatement() {
            InsertStatement insertStatement = base.FragmentFactory.CreateFragment<InsertStatement>();
            InsertSpecification insertSpecification = this.insertSpecification();
            if (base.inputState.guessing == 0) {
                insertStatement.InsertSpecification = insertSpecification;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0298;
                }
            } else {
                switch (num) {
                    case 111:
                        this.optimizerHints(insertStatement, insertStatement.OptimizerHints);
                        goto IL_0298;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0298;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0298:
            return insertStatement;
        }

        public UpdateStatement updateStatement() {
            UpdateStatement updateStatement = base.FragmentFactory.CreateFragment<UpdateStatement>();
            UpdateSpecification updateSpecification = this.updateSpecification();
            if (base.inputState.guessing == 0) {
                updateStatement.UpdateSpecification = updateSpecification;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0298;
                }
            } else {
                switch (num) {
                    case 111:
                        this.optimizerHints(updateStatement, updateStatement.OptimizerHints);
                        goto IL_0298;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0298;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0298:
            return updateStatement;
        }

        public TSqlStatement raiseErrorStatements() {
            TSqlStatement tSqlStatement = null;
            IToken token = null;
            token = this.LT(1);
            this.match(123);
            switch (this.LA(1)) {
                case 191:
                    tSqlStatement = this.raiseErrorStatement();
                    break;
                case 199:
                case 221:
                case 234:
                    tSqlStatement = this.raiseErrorLegacyStatement();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSqlStatement, token);
            }
            return tSqlStatement;
        }

        public CreateDatabaseStatement createDatabaseStatement() {
            CreateDatabaseStatement createDatabaseStatement = base.FragmentFactory.CreateFragment<CreateDatabaseStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(35);
            this.match(43);
            Identifier databaseName = this.identifier();
            if (base.inputState.guessing == 0) {
                createDatabaseStatement.DatabaseName = databaseName;
                TSql80ParserBaseInternal.UpdateTokenInfo(createDatabaseStatement, token);
                base.ThrowPartialAstIfPhaseOne(createDatabaseStatement);
            }
            this.recoveryUnitList(createDatabaseStatement);
            this.collationOpt(createDatabaseStatement);
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 67:
                        this.dbAddendums(createDatabaseStatement);
                        goto IL_02c2;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02c2;
                }
            } else {
                switch (num) {
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02c2;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02c2:
            return createDatabaseStatement;
        }

        public PrintStatement printStatement() {
            PrintStatement printStatement = base.FragmentFactory.CreateFragment<PrintStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(119);
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(printStatement, token);
                printStatement.Expression = expression;
            }
            return printStatement;
        }

        public WaitForStatement waitForStatement() {
            WaitForStatement waitForStatement = base.FragmentFactory.CreateFragment<WaitForStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(167);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(waitForStatement, token);
            }
            token2 = this.LT(1);
            this.match(232);
            ValueExpression parameter = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                waitForStatement.WaitForOption = WaitForOptionHelper.Instance.ParseOption(token2);
                waitForStatement.Parameter = parameter;
            }
            return waitForStatement;
        }

        public ReadTextStatement readTextStatement() {
            ReadTextStatement readTextStatement = base.FragmentFactory.CreateFragment<ReadTextStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(125);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(readTextStatement, token);
            }
            ColumnReferenceExpression column = this.column();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(column, true);
                readTextStatement.Column = column;
            }
            ValueExpression textPointer = this.binaryOrVariable();
            if (base.inputState.guessing == 0) {
                readTextStatement.TextPointer = textPointer;
            }
            textPointer = this.integerOrVariable();
            if (base.inputState.guessing == 0) {
                readTextStatement.Offset = textPointer;
            }
            textPointer = this.integerOrVariable();
            if (base.inputState.guessing == 0) {
                readTextStatement.Size = textPointer;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 78:
                        token2 = this.LT(1);
                        this.match(78);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(readTextStatement, token2);
                            readTextStatement.HoldLock = true;
                        }
                        goto IL_0361;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0361;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0361;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0361:
            return readTextStatement;
        }

        public UpdateTextStatement updateTextStatement() {
            UpdateTextStatement updateTextStatement = base.FragmentFactory.CreateFragment<UpdateTextStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(161);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(updateTextStatement, token);
            }
            this.modificationTextStatement(updateTextStatement);
            ScalarExpression insertOffset = this.signedIntegerOrVariableOrNull();
            if (base.inputState.guessing == 0) {
                updateTextStatement.InsertOffset = insertOffset;
            }
            insertOffset = this.signedIntegerOrVariableOrNull();
            if (base.inputState.guessing == 0) {
                updateTextStatement.DeleteLength = insertOffset;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 81:
                    case 82:
                    case 86:
                        goto IL_0350;
                }
            } else {
                switch (num) {
                    case 171:
                        this.modificationTextStatementWithLog(updateTextStatement);
                        goto IL_0350;
                    case 92:
                    case 95:
                    case 100:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 200:
                    case 204:
                    case 219:
                    case 220:
                    case 224:
                    case 227:
                    case 230:
                    case 231:
                    case 232:
                    case 233:
                    case 234:
                        goto IL_0350;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0677:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0350:
            int num2 = this.LA(1);
            ValueExpression sourceParameter;
            if (num2 <= 92) {
                switch (num2) {
                    case 81:
                        break;
                    default:
                        goto IL_0677;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_068a;
                }
            } else {
                switch (num2) {
                    case 136:
                    case 200:
                    case 227:
                    case 232:
                    case 233:
                        break;
                    case 100:
                    case 224:
                    case 230:
                    case 231:
                    case 234:
                        sourceParameter = this.writeString();
                        if (base.inputState.guessing == 0) {
                            updateTextStatement.SourceParameter = sourceParameter;
                        }
                        goto IL_068a;
                    default:
                        goto IL_0677;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_068a;
                }
            }
            ColumnReferenceExpression columnReferenceExpression = this.column();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(columnReferenceExpression, true);
                updateTextStatement.SourceColumn = columnReferenceExpression;
            }
            sourceParameter = this.binaryOrVariable();
            if (base.inputState.guessing == 0) {
                updateTextStatement.SourceParameter = sourceParameter;
            }
            goto IL_068a;
            IL_068a:
            return updateTextStatement;
        }

        public WriteTextStatement writeTextStatement() {
            WriteTextStatement writeTextStatement = base.FragmentFactory.CreateFragment<WriteTextStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(172);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(writeTextStatement, token);
            }
            this.modificationTextStatement(writeTextStatement);
            switch (this.LA(1)) {
                case 171:
                    this.modificationTextStatementWithLog(writeTextStatement);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 100:
                case 224:
                case 230:
                case 231:
                case 234:
                    break;
            }
            ValueExpression sourceParameter = this.writeString();
            if (base.inputState.guessing == 0) {
                writeTextStatement.SourceParameter = sourceParameter;
            }
            return writeTextStatement;
        }

        public LineNoStatement lineNoStatement() {
            LineNoStatement lineNoStatement = base.FragmentFactory.CreateFragment<LineNoStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(95);
            IntegerLiteral lineNo = this.integer();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(lineNoStatement, token);
                lineNoStatement.LineNo = lineNo;
            }
            return lineNoStatement;
        }

        public UseStatement useStatement() {
            UseStatement useStatement = base.FragmentFactory.CreateFragment<UseStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(162);
            Identifier databaseName = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(useStatement, token);
                useStatement.DatabaseName = databaseName;
            }
            return useStatement;
        }

        public KillStatement killStatement() {
            KillStatement killStatement = base.FragmentFactory.CreateFragment<KillStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(92);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(killStatement, token);
            }
            ScalarExpression parameter;
            switch (this.LA(1)) {
                case 199:
                case 221:
                    parameter = this.signedInteger();
                    break;
                case 230:
                case 231:
                    parameter = this.stringLiteral();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                killStatement.Parameter = parameter;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_035c;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "STATUSONLY");
                            killStatement.WithStatusOnly = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(killStatement, token2);
                        }
                        goto IL_035c;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_035c;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_035c:
            return killStatement;
        }

        public BulkInsertStatement bulkInsertStatement() {
            BulkInsertStatement bulkInsertStatement = base.FragmentFactory.CreateFragment<BulkInsertStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(17);
            this.match(86);
            SchemaObjectName to = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(bulkInsertStatement, token);
                bulkInsertStatement.To = to;
                base.ThrowPartialAstIfPhaseOne(bulkInsertStatement);
            }
            this.match(71);
            IdentifierOrValueExpression from = this.bulkInsertFrom();
            if (base.inputState.guessing == 0) {
                bulkInsertStatement.From = from;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02f2;
                }
            } else {
                switch (num) {
                    case 171:
                        this.bulkInsertOptions(bulkInsertStatement);
                        goto IL_02f2;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02f2;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02f2:
            return bulkInsertStatement;
        }

        public InsertBulkStatement insertBulkStatement() {
            InsertBulkStatement insertBulkStatement = base.FragmentFactory.CreateFragment<InsertBulkStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(86);
            this.match(17);
            SchemaObjectName to = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                insertBulkStatement.To = to;
                TSql80ParserBaseInternal.UpdateTokenInfo(insertBulkStatement, token);
                base.ThrowPartialAstIfPhaseOne(insertBulkStatement);
            }
            if (this.LA(1) == 191 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                this.coldefList(insertBulkStatement);
                goto IL_00bb;
            }
            if (TSql80ParserInternal.tokenSet_15_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_00bb;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00bb:
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_031f;
                }
            } else {
                switch (num) {
                    case 171:
                        this.insertBulkOptions(insertBulkStatement);
                        goto IL_031f;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_031f;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_031f:
            return insertBulkStatement;
        }

        public CheckpointStatement checkpointStatement() {
            CheckpointStatement checkpointStatement = base.FragmentFactory.CreateFragment<CheckpointStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(22);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(checkpointStatement, token);
            }
            return checkpointStatement;
        }

        public ReconfigureStatement reconfigureStatement() {
            ReconfigureStatement reconfigureStatement = base.FragmentFactory.CreateFragment<ReconfigureStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(126);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(reconfigureStatement, token);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02d5;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "OVERRIDE");
                            reconfigureStatement.WithOverride = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(reconfigureStatement, token2);
                        }
                        goto IL_02d5;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02d5;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02d5:
            return reconfigureStatement;
        }

        public ShutdownStatement shutdownStatement() {
            ShutdownStatement shutdownStatement = base.FragmentFactory.CreateFragment<ShutdownStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(144);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(shutdownStatement, token);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02d8;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "NOWAIT");
                            shutdownStatement.WithNoWait = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(shutdownStatement, token2);
                        }
                        goto IL_02d8;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02d8;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02d8:
            return shutdownStatement;
        }

        public SetUserStatement setUserStatement() {
            SetUserStatement setUserStatement = base.FragmentFactory.CreateFragment<SetUserStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(143);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(setUserStatement, token);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_05bd;
                }
                goto IL_05aa;
            }
            switch (num) {
                case 230:
                case 231:
                case 234:
                    break;
                default:
                    goto IL_05aa;
                case 95:
                case 106:
                case 119:
                case 123:
                case 125:
                case 126:
                case 129:
                case 131:
                case 132:
                case 134:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 204:
                case 219:
                case 220:
                    goto IL_05bd;
            }
            ValueExpression userName = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                setUserStatement.UserName = userName;
            }
            int num2 = this.LA(1);
            if (num2 <= 86) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_05bd;
                }
            } else {
                switch (num2) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "NORESET");
                            setUserStatement.WithNoReset = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(setUserStatement, token2);
                        }
                        goto IL_05bd;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_05bd;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_05aa:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_05bd:
            return setUserStatement;
        }

        public TruncateTableStatement truncateTableStatement() {
            TruncateTableStatement truncateTableStatement = base.FragmentFactory.CreateFragment<TruncateTableStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(156);
            this.match(148);
            SchemaObjectName tableName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(truncateTableStatement, token);
                truncateTableStatement.TableName = tableName;
            }
            return truncateTableStatement;
        }

        public GrantStatement80 grantStatement80() {
            GrantStatement80 grantStatement = base.FragmentFactory.CreateFragment<GrantStatement80>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(75);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(grantStatement, token);
            }
            SecurityElement80 securityElement = this.securityElement80();
            if (base.inputState.guessing == 0) {
                grantStatement.SecurityElement80 = securityElement;
            }
            this.match(151);
            SecurityUserClause80 securityUserClause = this.securityUserClause80();
            if (base.inputState.guessing == 0) {
                grantStatement.SecurityUserClause80 = securityUserClause;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 9:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_033a;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        this.match(75);
                        token2 = this.LT(1);
                        this.match(111);
                        if (base.inputState.guessing == 0) {
                            grantStatement.WithGrantOption = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(grantStatement, token2);
                        }
                        goto IL_033a;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_033a;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_033a:
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 9: {
                            this.match(9);
                            Identifier asClause = this.identifier();
                            if (base.inputState.guessing == 0) {
                                grantStatement.AsClause = asClause;
                            }
                            goto IL_05e5;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_05e5;
                }
            } else {
                switch (num2) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_05e5;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_05e5:
            return grantStatement;
        }

        public DenyStatement80 denyStatement80() {
            DenyStatement80 denyStatement = base.FragmentFactory.CreateFragment<DenyStatement80>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(49);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(denyStatement, token);
            }
            SecurityElement80 securityElement = this.securityElement80();
            if (base.inputState.guessing == 0) {
                denyStatement.SecurityElement80 = securityElement;
            }
            this.match(151);
            SecurityUserClause80 securityUserClause = this.securityUserClause80();
            if (base.inputState.guessing == 0) {
                denyStatement.SecurityUserClause80 = securityUserClause;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 19:
                        token2 = this.LT(1);
                        this.match(19);
                        if (base.inputState.guessing == 0) {
                            denyStatement.CascadeOption = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(denyStatement, token2);
                        }
                        goto IL_0322;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0322;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0322;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0322:
            return denyStatement;
        }

        public RevokeStatement80 revokeStatement80() {
            RevokeStatement80 revokeStatement = base.FragmentFactory.CreateFragment<RevokeStatement80>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(132);
            switch (this.LA(1)) {
                case 75:
                    this.match(75);
                    this.match(111);
                    this.match(67);
                    if (base.inputState.guessing == 0) {
                        revokeStatement.GrantOptionFor = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 5:
                case 12:
                case 35:
                case 48:
                case 60:
                case 61:
                case 86:
                case 127:
                case 140:
                case 160:
                    break;
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(revokeStatement, token);
            }
            SecurityElement80 securityElement = this.securityElement80();
            if (base.inputState.guessing == 0) {
                revokeStatement.SecurityElement80 = securityElement;
            }
            switch (this.LA(1)) {
                case 151:
                    this.match(151);
                    break;
                case 71:
                    this.match(71);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            SecurityUserClause80 securityUserClause = this.securityUserClause80();
            if (base.inputState.guessing == 0) {
                revokeStatement.SecurityUserClause80 = securityUserClause;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 19:
                        token2 = this.LT(1);
                        this.match(19);
                        if (base.inputState.guessing == 0) {
                            revokeStatement.CascadeOption = true;
                            TSql80ParserBaseInternal.UpdateTokenInfo(revokeStatement, token2);
                        }
                        goto IL_042b;
                    case 1:
                    case 6:
                    case 9:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_042b;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_042b;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_06d6:
            return revokeStatement;
            IL_042b:
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 9: {
                            this.match(9);
                            Identifier asClause = this.identifier();
                            if (base.inputState.guessing == 0) {
                                revokeStatement.AsClause = asClause;
                            }
                            goto IL_06d6;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_06d6;
                }
            } else {
                switch (num2) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_06d6;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ReturnStatement returnStatement() {
            ReturnStatement returnStatement = base.FragmentFactory.CreateFragment<ReturnStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(131);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(returnStatement, token);
            }
            bool flag = false;
            if (TSql80ParserInternal.tokenSet_16_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_17_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.expression();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                ScalarExpression expression = this.expression();
                if (base.inputState.guessing == 0) {
                    returnStatement.Expression = expression;
                }
                goto IL_00fc;
            }
            if (TSql80ParserInternal.tokenSet_10_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_00fc;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00fc:
            return returnStatement;
        }

        public OpenCursorStatement openCursorStatement() {
            OpenCursorStatement openCursorStatement = base.FragmentFactory.CreateFragment<OpenCursorStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(106);
            CursorId cursor = this.cursorId();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(openCursorStatement, token);
                openCursorStatement.Cursor = cursor;
            }
            return openCursorStatement;
        }

        public CloseCursorStatement closeCursorStatement() {
            CloseCursorStatement closeCursorStatement = base.FragmentFactory.CreateFragment<CloseCursorStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(23);
            CursorId cursor = this.cursorId();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(closeCursorStatement, token);
                closeCursorStatement.Cursor = cursor;
            }
            return closeCursorStatement;
        }

        public DeallocateCursorStatement deallocateCursorStatement() {
            DeallocateCursorStatement deallocateCursorStatement = base.FragmentFactory.CreateFragment<DeallocateCursorStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(45);
            CursorId cursor = this.cursorId();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(deallocateCursorStatement, token);
                deallocateCursorStatement.Cursor = cursor;
            }
            return deallocateCursorStatement;
        }

        public FetchCursorStatement fetchCursorStatement() {
            IToken token = null;
            token = this.LT(1);
            this.match(64);
            FetchCursorStatement fetchCursorStatement = this.rowSelector();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fetchCursorStatement, token);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 88: {
                            this.match(88);
                            VariableReference item = this.variable();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fetchCursorStatement, fetchCursorStatement.IntoVariables, item);
                            }
                            while (true) {
                                if (this.LA(1) != 198) {
                                    break;
                                }
                                this.match(198);
                                item = this.variable();
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fetchCursorStatement, fetchCursorStatement.IntoVariables, item);
                                }
                            }
                            goto IL_0305;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0305;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0305;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0305:
            return fetchCursorStatement;
        }

        public TSqlStatement dropStatements() {
            IToken token = null;
            token = this.LT(1);
            this.match(54);
            TSqlStatement tSqlStatement;
            switch (this.LA(1)) {
                case 43:
                    tSqlStatement = this.dropDatabaseStatement();
                    break;
                case 84:
                    tSqlStatement = this.dropIndexStatement();
                    break;
                case 146:
                    tSqlStatement = this.dropStatisticsStatement();
                    break;
                case 148:
                    tSqlStatement = this.dropTableStatement();
                    break;
                case 120:
                case 121:
                    tSqlStatement = this.dropProcedureStatement();
                    break;
                case 73:
                    tSqlStatement = this.dropFunctionStatement();
                    break;
                case 166:
                    tSqlStatement = this.dropViewStatement();
                    break;
                case 47:
                    tSqlStatement = this.dropDefaultStatement();
                    break;
                case 137:
                    tSqlStatement = this.dropRuleStatement();
                    break;
                case 155:
                    tSqlStatement = this.dropTriggerStatement();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSqlStatement, token);
            }
            return tSqlStatement;
        }

        public DbccStatement dbccStatement() {
            DbccStatement dbccStatement = base.FragmentFactory.CreateFragment<DbccStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(44);
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                DbccCommand command = default(DbccCommand);
                if (((OptionsHelper<DbccCommand>)DbccCommandsHelper.Instance).TryParseOption(token2, out command)) {
                    dbccStatement.Command = command;
                } else {
                    dbccStatement.Command = DbccCommand.Free;
                    dbccStatement.DllName = token2.getText();
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(dbccStatement, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(dbccStatement, token2);
            }
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_18_.member(this.LA(2))) {
                this.dbccNamedLiteralList(dbccStatement);
                goto IL_00dd;
            }
            if (TSql80ParserInternal.tokenSet_15_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_00dd;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_035d:
            return dbccStatement;
            IL_00dd:
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_035d;
                }
            } else {
                switch (num) {
                    case 171:
                        this.dbccOptions(dbccStatement);
                        goto IL_035d;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_035d;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public RevertStatement revertStatement() {
            RevertStatement revertStatement = base.FragmentFactory.CreateFragment<RevertStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(176);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(revertStatement, token);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0302;
                }
            } else {
                switch (num) {
                    case 171: {
                            this.match(171);
                            token2 = this.LT(1);
                            this.match(232);
                            this.match(206);
                            ScalarExpression cookie = this.expression();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.Match(token2, "COOKIE");
                                revertStatement.Cookie = cookie;
                            }
                            goto IL_0302;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0302;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0302:
            return revertStatement;
        }

        public DiskStatement diskStatement() {
            DiskStatement diskStatement = base.FragmentFactory.CreateFragment<DiskStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(173);
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                if (TSql80ParserBaseInternal.TryMatch(token2, "INIT")) {
                    diskStatement.DiskStatementType = DiskStatementType.Init;
                } else {
                    TSql80ParserBaseInternal.Match(token2, "RESIZE");
                    diskStatement.DiskStatementType = DiskStatementType.Resize;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(diskStatement, token);
            }
            DiskStatementOption item = this.diskStatementOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(diskStatement, diskStatement.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.diskStatementOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(diskStatement, diskStatement.Options, item);
                }
            }
            return diskStatement;
        }

        public CreateProcedureStatement createProcedureStatement() {
            CreateProcedureStatement createProcedureStatement = base.FragmentFactory.CreateFragment<CreateProcedureStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createProcedureStatement, token);
            }
            this.procedureStatementBody((ProcedureStatementBody)createProcedureStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                createProcedureStatement = null;
            }
            return createProcedureStatement;
        }

        public AlterProcedureStatement alterProcedureStatement() {
            AlterProcedureStatement alterProcedureStatement = base.FragmentFactory.CreateFragment<AlterProcedureStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(6);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(alterProcedureStatement, token);
            }
            this.procedureStatementBody((ProcedureStatementBody)alterProcedureStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                alterProcedureStatement = null;
            }
            return alterProcedureStatement;
        }

        public CreateTriggerStatement createTriggerStatement() {
            CreateTriggerStatement createTriggerStatement = base.FragmentFactory.CreateFragment<CreateTriggerStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createTriggerStatement, token);
            }
            this.triggerStatementBody((TriggerStatementBody)createTriggerStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                createTriggerStatement = null;
            }
            return createTriggerStatement;
        }

        public AlterTriggerStatement alterTriggerStatement() {
            AlterTriggerStatement alterTriggerStatement = base.FragmentFactory.CreateFragment<AlterTriggerStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(6);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(alterTriggerStatement, token);
            }
            this.triggerStatementBody((TriggerStatementBody)alterTriggerStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                alterTriggerStatement = null;
            }
            return alterTriggerStatement;
        }

        public CreateDefaultStatement createDefaultStatement() {
            CreateDefaultStatement createDefaultStatement = base.FragmentFactory.CreateFragment<CreateDefaultStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(35);
            this.match(47);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createDefaultStatement, token);
            }
            SchemaObjectName name = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(name, "DEFAULT");
                createDefaultStatement.Name = name;
                base.ThrowPartialAstIfPhaseOne(createDefaultStatement);
            }
            this.match(9);
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                createDefaultStatement.Expression = expression;
            }
            return createDefaultStatement;
        }

        public CreateRuleStatement createRuleStatement() {
            CreateRuleStatement createRuleStatement = base.FragmentFactory.CreateFragment<CreateRuleStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(35);
            this.match(137);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createRuleStatement, token);
            }
            SchemaObjectName name = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(name, "RULE");
                createRuleStatement.Name = name;
                base.ThrowPartialAstIfPhaseOne(createRuleStatement);
            }
            this.match(9);
            BooleanExpression expression = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                createRuleStatement.Expression = expression;
            }
            return createRuleStatement;
        }

        public CreateViewStatement createViewStatement() {
            CreateViewStatement createViewStatement = base.FragmentFactory.CreateFragment<CreateViewStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createViewStatement, token);
            }
            this.viewStatementBody(createViewStatement);
            return createViewStatement;
        }

        public AlterViewStatement alterViewStatement() {
            AlterViewStatement alterViewStatement = base.FragmentFactory.CreateFragment<AlterViewStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(6);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(alterViewStatement, token);
            }
            this.viewStatementBody(alterViewStatement);
            return alterViewStatement;
        }

        public CreateFunctionStatement createFunctionStatement() {
            CreateFunctionStatement createFunctionStatement = base.FragmentFactory.CreateFragment<CreateFunctionStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createFunctionStatement, token);
            }
            this.functionStatementBody((FunctionStatementBody)createFunctionStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                createFunctionStatement = null;
            }
            return createFunctionStatement;
        }

        public AlterFunctionStatement alterFunctionStatement() {
            AlterFunctionStatement alterFunctionStatement = base.FragmentFactory.CreateFragment<AlterFunctionStatement>();
            IToken token = null;
            bool flag = false;
            token = this.LT(1);
            this.match(6);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(alterFunctionStatement, token);
            }
            this.functionStatementBody((FunctionStatementBody)alterFunctionStatement, out flag);
            if (base.inputState.guessing == 0 && flag) {
                alterFunctionStatement = null;
            }
            return alterFunctionStatement;
        }

        public CreateSchemaStatement createSchemaStatement() {
            CreateSchemaStatement createSchemaStatement = base.FragmentFactory.CreateFragment<CreateSchemaStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(35);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(createSchemaStatement, token);
            }
            this.match(139);
            switch (this.LA(1)) {
                case 232:
                case 233: {
                        Identifier name = this.identifier();
                        if (base.inputState.guessing == 0) {
                            createSchemaStatement.Name = name;
                        }
                        this.authorizationOpt(createSchemaStatement);
                        break;
                    }
                case 11:
                    this.authorization(createSchemaStatement);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(createSchemaStatement);
            }
            StatementList statementList = this.createSchemaElementList();
            if (base.inputState.guessing == 0) {
                createSchemaStatement.StatementList = statementList;
            }
            return createSchemaStatement;
        }

        public Identifier identifier() {
            Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
                        identifier.SetUnquotedIdentifier(token.getText());
                        TSql80ParserBaseInternal.CheckIdentifierLength(identifier);
                    }
                    break;
                case 233:
                    token2 = this.LT(1);
                    this.match(233);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token2);
                        identifier.SetIdentifier(token2.getText());
                        TSql80ParserBaseInternal.CheckIdentifierLength(identifier);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifier;
        }

        public SqlCommandIdentifier sqlCommandIdentifier() {
            SqlCommandIdentifier sqlCommandIdentifier = base.FragmentFactory.CreateFragment<SqlCommandIdentifier>();
            IToken token = null;
            token = this.LT(1);
            this.match(226);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(sqlCommandIdentifier, token);
                sqlCommandIdentifier.SetUnquotedIdentifier(token.getText());
            }
            return sqlCommandIdentifier;
        }

        public AlterDatabaseStatement alterDbAdd() {
            AlterDatabaseStatement alterDatabaseStatement = null;
            this.match(4);
            if (this.LA(1) != 65 && this.LA(1) != 232) {
                goto IL_0044;
            }
            if (this.LA(2) != 65 && this.LA(2) != 191) {
                goto IL_0044;
            }
            return this.alterDbAddFile();
            IL_0044:
            if (this.LA(1) == 232 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                return this.alterDbAddFilegroup();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public AlterDatabaseStatement alterDbRemove() {
            AlterDatabaseStatement result = null;
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "REMOVE");
            }
            switch (this.LA(1)) {
                case 65: {
                        this.match(65);
                        Identifier fileGroup = this.identifier();
                        if (base.inputState.guessing == 0) {
                            AlterDatabaseRemoveFileStatement alterDatabaseRemoveFileStatement = base.FragmentFactory.CreateFragment<AlterDatabaseRemoveFileStatement>();
                            alterDatabaseRemoveFileStatement.File = fileGroup;
                            result = alterDatabaseRemoveFileStatement;
                        }
                        break;
                    }
                case 232: {
                        token2 = this.LT(1);
                        this.match(232);
                        Identifier fileGroup = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "FILEGROUP");
                            AlterDatabaseRemoveFileGroupStatement alterDatabaseRemoveFileGroupStatement = base.FragmentFactory.CreateFragment<AlterDatabaseRemoveFileGroupStatement>();
                            alterDatabaseRemoveFileGroupStatement.FileGroup = fileGroup;
                            result = alterDatabaseRemoveFileGroupStatement;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public AlterDatabaseStatement alterDbModify() {
            AlterDatabaseStatement result = null;
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "MODIFY");
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("NAME")) {
                token2 = this.LT(1);
                this.match(232);
                this.match(206);
                Identifier newDatabaseName = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token2, "NAME");
                    AlterDatabaseModifyNameStatement alterDatabaseModifyNameStatement = base.FragmentFactory.CreateFragment<AlterDatabaseModifyNameStatement>();
                    alterDatabaseModifyNameStatement.NewDatabaseName = newDatabaseName;
                    result = alterDatabaseModifyNameStatement;
                }
                goto IL_0140;
            }
            if (this.LA(1) == 232 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                token3 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token3, "FILEGROUP");
                }
                result = this.alterDbModifyFilegroup();
                goto IL_0140;
            }
            if (this.LA(1) == 65) {
                result = this.alterDbModifyFile();
                goto IL_0140;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0140:
            return result;
        }

        public AlterDatabaseSetStatement alterDbSet() {
            this.match(142);
            AlterDatabaseSetStatement alterDatabaseSetStatement = this.dbOptionStateList();
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_028a;
                }
            } else {
                switch (num) {
                    case 171: {
                            AlterDatabaseTermination termination = this.xactTermination();
                            if (base.inputState.guessing == 0) {
                                alterDatabaseSetStatement.Termination = termination;
                            }
                            goto IL_028a;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_028a;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_028a:
            return alterDatabaseSetStatement;
        }

        public AlterDatabaseCollateStatement alterDbCollate() {
            AlterDatabaseCollateStatement alterDatabaseCollateStatement = base.FragmentFactory.CreateFragment<AlterDatabaseCollateStatement>();
            this.collation(alterDatabaseCollateStatement);
            return alterDatabaseCollateStatement;
        }

        public void collation(ICollationSetter vParent) {
            this.match(26);
            Identifier collation = this.nonQuotedIdentifier();
            if (base.inputState.guessing == 0) {
                vParent.Collation = collation;
            }
        }

        public AlterDatabaseAddFileStatement alterDbAddFile() {
            AlterDatabaseAddFileStatement alterDatabaseAddFileStatement = base.FragmentFactory.CreateFragment<AlterDatabaseAddFileStatement>();
            IToken token = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token, "LOG");
                        alterDatabaseAddFileStatement.IsLog = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 65:
                    break;
            }
            this.match(65);
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(alterDatabaseAddFileStatement);
            }
            this.fileDeclBodyList(alterDatabaseAddFileStatement, alterDatabaseAddFileStatement.FileDeclarations);
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0343;
                }
                goto IL_0330;
            }
            switch (num) {
                case 151:
                    break;
                default:
                    goto IL_0330;
                case 95:
                case 106:
                case 119:
                case 123:
                case 125:
                case 126:
                case 129:
                case 131:
                case 132:
                case 134:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 204:
                case 219:
                case 220:
                    goto IL_0343;
            }
            Identifier identifier = this.toFilegroup();
            if (base.inputState.guessing == 0) {
                if (alterDatabaseAddFileStatement.IsLog) {
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(identifier);
                }
                alterDatabaseAddFileStatement.FileGroup = identifier;
            }
            goto IL_0343;
            IL_0330:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0343:
            return alterDatabaseAddFileStatement;
        }

        public AlterDatabaseAddFileGroupStatement alterDbAddFilegroup() {
            AlterDatabaseAddFileGroupStatement alterDatabaseAddFileGroupStatement = base.FragmentFactory.CreateFragment<AlterDatabaseAddFileGroupStatement>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            Identifier fileGroup = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "FILEGROUP");
                alterDatabaseAddFileGroupStatement.FileGroup = fileGroup;
            }
            return alterDatabaseAddFileGroupStatement;
        }

        public void fileDeclBodyList(TSqlFragment vParent, IList<FileDeclaration> fileDeclarations) {
            FileDeclaration item = this.fileDeclBody(false);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, fileDeclarations, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.fileDeclBody(false);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, fileDeclarations, item);
                }
            }
        }

        public Identifier toFilegroup() {
            IToken token = null;
            this.match(151);
            token = this.LT(1);
            this.match(232);
            Identifier result = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "FILEGROUP");
            }
            return result;
        }

        public AlterDatabaseModifyFileGroupStatement alterDbModifyFilegroup() {
            AlterDatabaseModifyFileGroupStatement alterDatabaseModifyFileGroupStatement = base.FragmentFactory.CreateFragment<AlterDatabaseModifyFileGroupStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            Identifier fileGroup = this.identifier();
            if (base.inputState.guessing == 0) {
                alterDatabaseModifyFileGroupStatement.FileGroup = fileGroup;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206) {
                token = this.LT(1);
                this.match(232);
                this.match(206);
                Identifier newFileGroupName = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token, "NAME");
                    alterDatabaseModifyFileGroupStatement.NewFileGroupName = newFileGroupName;
                    base.ThrowPartialAstIfPhaseOne(alterDatabaseModifyFileGroupStatement);
                }
                goto IL_0151;
            }
            if (this.LA(1) == 47) {
                token2 = this.LT(1);
                this.match(47);
                if (base.inputState.guessing == 0) {
                    alterDatabaseModifyFileGroupStatement.MakeDefault = true;
                    TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseModifyFileGroupStatement, token2);
                }
                goto IL_0151;
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_10_.member(this.LA(2))) {
                token3 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    base.ThrowPartialAstIfPhaseOne(alterDatabaseModifyFileGroupStatement);
                    alterDatabaseModifyFileGroupStatement.UpdatabilityOption = ModifyFilegroupOptionsHelper.Instance.ParseOption(token3, SqlVersionFlags.TSql80);
                    TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseModifyFileGroupStatement, token3);
                }
                goto IL_0151;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0151:
            return alterDatabaseModifyFileGroupStatement;
        }

        public AlterDatabaseModifyFileStatement alterDbModifyFile() {
            AlterDatabaseModifyFileStatement alterDatabaseModifyFileStatement = base.FragmentFactory.CreateFragment<AlterDatabaseModifyFileStatement>();
            this.match(65);
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(alterDatabaseModifyFileStatement);
            }
            FileDeclaration fileDeclaration = this.fileDecl(true);
            if (base.inputState.guessing == 0) {
                alterDatabaseModifyFileStatement.FileDeclaration = fileDeclaration;
            }
            return alterDatabaseModifyFileStatement;
        }

        public FileDeclaration fileDecl(bool isAlterDbModifyFileStatement) {
            IToken token = null;
            FileDeclaration fileDeclaration;
            switch (this.LA(1)) {
                case 118:
                    token = this.LT(1);
                    this.match(118);
                    fileDeclaration = this.fileDeclBody(isAlterDbModifyFileStatement);
                    if (base.inputState.guessing == 0) {
                        fileDeclaration.IsPrimary = true;
                        TSql80ParserBaseInternal.UpdateTokenInfo(fileDeclaration, token);
                    }
                    break;
                case 191:
                    fileDeclaration = this.fileDeclBody(isAlterDbModifyFileStatement);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return fileDeclaration;
        }

        public AlterDatabaseSetStatement dbOptionStateList() {
            AlterDatabaseSetStatement alterDatabaseSetStatement = base.FragmentFactory.CreateFragment<AlterDatabaseSetStatement>();
            DatabaseOption item = this.dbOptionStateItem();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterDatabaseSetStatement, alterDatabaseSetStatement.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.dbOptionStateItem();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterDatabaseSetStatement, alterDatabaseSetStatement.Options, item);
                }
            }
            return alterDatabaseSetStatement;
        }

        public AlterDatabaseTermination xactTermination() {
            AlterDatabaseTermination alterDatabaseTermination = base.FragmentFactory.CreateFragment<AlterDatabaseTermination>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            token = this.LT(1);
            this.match(171);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseTermination, token);
            }
            switch (this.LA(1)) {
                case 134:
                    this.match(134);
                    if (this.LA(1) == 232 && this.LA(2) == 221) {
                        token2 = this.LT(1);
                        this.match(232);
                        Literal rollbackAfter = this.integer();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token2, "AFTER");
                            alterDatabaseTermination.RollbackAfter = rollbackAfter;
                        }
                        int num = this.LA(1);
                        if (num <= 92) {
                            switch (num) {
                                case 1:
                                case 6:
                                case 12:
                                case 13:
                                case 15:
                                case 17:
                                case 22:
                                case 23:
                                case 28:
                                case 33:
                                case 35:
                                case 44:
                                case 45:
                                case 46:
                                case 48:
                                case 49:
                                case 54:
                                case 55:
                                case 56:
                                case 60:
                                case 61:
                                case 64:
                                case 74:
                                case 75:
                                case 82:
                                case 86:
                                case 92:
                                    goto end_IL_0000;
                            }
                        } else {
                            switch (num) {
                                case 232:
                                    token3 = this.LT(1);
                                    this.match(232);
                                    if (base.inputState.guessing == 0) {
                                        TSql80ParserBaseInternal.Match(token3, "SECONDS");
                                        TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseTermination, token3);
                                    }
                                    goto end_IL_0000;
                                case 95:
                                case 106:
                                case 119:
                                case 123:
                                case 125:
                                case 126:
                                case 129:
                                case 131:
                                case 132:
                                case 134:
                                case 138:
                                case 140:
                                case 142:
                                case 143:
                                case 144:
                                case 156:
                                case 160:
                                case 161:
                                case 162:
                                case 167:
                                case 170:
                                case 172:
                                case 173:
                                case 176:
                                case 180:
                                case 181:
                                case 191:
                                case 204:
                                case 219:
                                case 220:
                                    goto end_IL_0000;
                            }
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_10_.member(this.LA(2))) {
                        token4 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token4, "IMMEDIATE");
                            TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseTermination, token4);
                            alterDatabaseTermination.ImmediateRollback = true;
                        }
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 232:
                    token5 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token5, "NO_WAIT");
                        TSql80ParserBaseInternal.UpdateTokenInfo(alterDatabaseTermination, token5);
                        alterDatabaseTermination.NoWait = true;
                    }
                    break;
                default: {
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    end_IL_0000:
                    break;
            }
            return alterDatabaseTermination;
        }

        public IntegerLiteral integer() {
            IntegerLiteral integerLiteral = base.FragmentFactory.CreateFragment<IntegerLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(221);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(integerLiteral, token);
                integerLiteral.Value = token.getText();
            }
            return integerLiteral;
        }

        public DatabaseOption dbOptionStateItem() {
            DatabaseOption databaseOption = null;
            if (this.LA(1) == 232 && this.LA(2) == 232 && base.NextTokenMatches("CURSOR_DEFAULT")) {
                return this.cursorDefaultDbOption();
            }
            if (this.LA(1) == 232 && (this.LA(2) == 72 || this.LA(2) == 232) && base.NextTokenMatches("RECOVERY")) {
                return this.recoveryDbOption();
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_19_.member(this.LA(2))) {
                return this.dbSingleIdentOption();
            }
            if (this.LA(1) == 232 && (this.LA(2) == 103 || this.LA(2) == 105)) {
                return this.alterDbOnOffOption();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public CursorDefaultDatabaseOption cursorDefaultDbOption() {
            CursorDefaultDatabaseOption cursorDefaultDatabaseOption = base.FragmentFactory.CreateFragment<CursorDefaultDatabaseOption>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "CURSOR_DEFAULT");
                cursorDefaultDatabaseOption.OptionKind = DatabaseOptionKind.CursorDefault;
                if (TSql80ParserBaseInternal.TryMatch(token2, "LOCAL")) {
                    cursorDefaultDatabaseOption.IsLocal = true;
                } else {
                    TSql80ParserBaseInternal.Match(token2, "GLOBAL");
                    cursorDefaultDatabaseOption.IsLocal = false;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(cursorDefaultDatabaseOption, token2);
            }
            return cursorDefaultDatabaseOption;
        }

        public RecoveryDatabaseOption recoveryDbOption() {
            RecoveryDatabaseOption recoveryDatabaseOption = base.FragmentFactory.CreateFragment<RecoveryDatabaseOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "RECOVERY");
                recoveryDatabaseOption.OptionKind = DatabaseOptionKind.Recovery;
            }
            switch (this.LA(1)) {
                case 72:
                    token2 = this.LT(1);
                    this.match(72);
                    if (base.inputState.guessing == 0) {
                        recoveryDatabaseOption.Value = RecoveryDatabaseOptionKind.Full;
                        TSql80ParserBaseInternal.UpdateTokenInfo(recoveryDatabaseOption, token2);
                    }
                    break;
                case 232:
                    token3 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        recoveryDatabaseOption.Value = RecoveryDbOptionsHelper.Instance.ParseOption(token3);
                        TSql80ParserBaseInternal.UpdateTokenInfo(recoveryDatabaseOption, token3);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return recoveryDatabaseOption;
        }

        public DatabaseOption dbSingleIdentOption() {
            DatabaseOption databaseOption = base.FragmentFactory.CreateFragment<DatabaseOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                databaseOption.OptionKind = SimpleDbOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                TSql80ParserBaseInternal.UpdateTokenInfo(databaseOption, token);
            }
            return databaseOption;
        }

        public OnOffDatabaseOption alterDbOnOffOption() {
            OnOffDatabaseOption onOffDatabaseOption = base.FragmentFactory.CreateFragment<OnOffDatabaseOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            OptionState optionState = this.optionOnOff(onOffDatabaseOption);
            if (base.inputState.guessing == 0) {
                onOffDatabaseOption.OptionKind = OnOffSimpleDbOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                onOffDatabaseOption.OptionState = optionState;
            }
            return onOffDatabaseOption;
        }

        public OptionState optionOnOff(TSqlFragment vParent) {
            OptionState result = OptionState.NotSet;
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 105:
                    token = this.LT(1);
                    this.match(105);
                    if (base.inputState.guessing == 0) {
                        result = OptionState.On;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                case 103:
                    token2 = this.LT(1);
                    this.match(103);
                    if (base.inputState.guessing == 0) {
                        result = OptionState.Off;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public void recoveryUnitList(CreateDatabaseStatement vParent) {
            IToken token = null;
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 26:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0284;
                }
            } else {
                switch (num) {
                    case 105:
                        this.onDisk(vParent);
                        goto IL_0284;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                    case 232:
                        goto IL_0284;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0284:
            if (this.LA(1) == 232 && base.NextTokenMatches("LOG")) {
                token = this.LT(1);
                this.match(232);
                this.match(105);
                this.fileDeclBodyList(vParent, vParent.LogOn);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token, "LOG");
                }
            } else if (!TSql80ParserInternal.tokenSet_20_.member(this.LA(1))) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void collationOpt(ICollationSetter vParent) {
            switch (this.LA(1)) {
                case 1:
                case 6:
                case 7:
                case 9:
                case 10:
                case 12:
                case 13:
                case 14:
                case 15:
                case 17:
                case 21:
                case 22:
                case 23:
                case 28:
                case 29:
                case 30:
                case 33:
                case 35:
                case 36:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 54:
                case 55:
                case 56:
                case 58:
                case 59:
                case 60:
                case 61:
                case 64:
                case 67:
                case 68:
                case 71:
                case 72:
                case 74:
                case 75:
                case 76:
                case 77:
                case 79:
                case 82:
                case 83:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                case 92:
                case 93:
                case 94:
                case 95:
                case 99:
                case 100:
                case 105:
                case 106:
                case 111:
                case 112:
                case 113:
                case 114:
                case 118:
                case 119:
                case 123:
                case 125:
                case 126:
                case 127:
                case 129:
                case 131:
                case 132:
                case 133:
                case 134:
                case 136:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 150:
                case 156:
                case 158:
                case 159:
                case 160:
                case 161:
                case 162:
                case 167:
                case 168:
                case 169:
                case 170:
                case 171:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 188:
                case 189:
                case 190:
                case 191:
                case 192:
                case 193:
                case 194:
                case 195:
                case 196:
                case 197:
                case 198:
                case 199:
                case 201:
                case 204:
                case 205:
                case 206:
                case 207:
                case 208:
                case 209:
                case 210:
                case 219:
                case 220:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                    break;
                case 26:
                    this.collation(vParent);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void dbAddendums(CreateDatabaseStatement vParent) {
            IToken token = null;
            IToken token2 = null;
            this.match(67);
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token, "ATTACH");
                        vParent.AttachMode = AttachMode.Attach;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                case 181:
                    token2 = this.LT(1);
                    this.match(181);
                    if (base.inputState.guessing == 0) {
                        vParent.AttachMode = AttachMode.Load;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        return;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 232:
                        this.match(232);
                        return;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void onDisk(CreateDatabaseStatement vParent) {
            FileGroupDefinition fileGroupDefinition = base.FragmentFactory.CreateFragment<FileGroupDefinition>();
            vParent.FileGroups.Add(fileGroupDefinition);
            this.match(105);
            FileDeclaration fileDeclaration = this.fileDecl(false);
            if (base.inputState.guessing == 0) {
                fileGroupDefinition.FileDeclarations.Add(fileDeclaration);
                vParent.UpdateTokenInfo(fileDeclaration);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                switch (this.LA(1)) {
                    case 118:
                    case 191:
                        fileDeclaration = this.fileDecl(false);
                        if (base.inputState.guessing == 0) {
                            fileGroupDefinition.FileDeclarations.Add(fileDeclaration);
                            vParent.UpdateTokenInfo(fileDeclaration);
                        }
                        break;
                    case 232: {
                            FileGroupDefinition fileGroupDefinition2 = this.fileGroupDecl();
                            if (base.inputState.guessing == 0) {
                                fileGroupDefinition = fileGroupDefinition2;
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.FileGroups, fileGroupDefinition);
                            }
                            break;
                        }
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
            }
        }

        public FileGroupDefinition fileGroupDecl() {
            FileGroupDefinition fileGroupDefinition = base.FragmentFactory.CreateFragment<FileGroupDefinition>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            Identifier name = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "FILEGROUP");
                TSql80ParserBaseInternal.UpdateTokenInfo(fileGroupDefinition, token);
                fileGroupDefinition.Name = name;
            }
            switch (this.LA(1)) {
                case 47:
                    this.match(47);
                    if (base.inputState.guessing == 0) {
                        fileGroupDefinition.IsDefault = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 191:
                    break;
            }
            FileDeclaration item = this.fileDeclBody(false);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fileGroupDefinition, fileGroupDefinition.FileDeclarations, item);
            }
            return fileGroupDefinition;
        }

        public FileDeclaration fileDeclBody(bool isAlterDbModifyFileStatement) {
            FileDeclaration fileDeclaration = base.FragmentFactory.CreateFragment<FileDeclaration>();
            IToken token = null;
            IToken token2 = null;
            int num = 0;
            token = this.LT(1);
            this.match(191);
            FileDeclarationOption fileDeclarationOption = this.fileOption(isAlterDbModifyFileStatement);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fileDeclaration, token);
                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)fileDeclarationOption.OptionKind, fileDeclarationOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fileDeclaration, fileDeclaration.Options, fileDeclarationOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                fileDeclarationOption = this.fileOption(isAlterDbModifyFileStatement);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)fileDeclarationOption.OptionKind, fileDeclarationOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fileDeclaration, fileDeclaration.Options, fileDeclarationOption);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fileDeclaration, token2);
                if (!isAlterDbModifyFileStatement && (num & 8) == 0) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46065", fileDeclaration, TSqlParserResource.SQL46065Message);
                }
            }
            return fileDeclaration;
        }

        public FileDeclarationOption fileOption(bool newNameAllowed) {
            FileDeclarationOption fileDeclarationOption = null;
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("NAME")) {
                fileDeclarationOption = this.nameFileOption();
                goto IL_0173;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("FILENAME")) {
                fileDeclarationOption = this.fileNameFileOption();
                goto IL_0173;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("SIZE")) {
                fileDeclarationOption = this.sizeFileOption();
                goto IL_0173;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("MAXSIZE")) {
                fileDeclarationOption = this.maxSizeFileOption();
                goto IL_0173;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("FILEGROWTH")) {
                fileDeclarationOption = this.fileGrowthFileOption();
                goto IL_0173;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206 && base.NextTokenMatches("NEWNAME")) {
                fileDeclarationOption = this.newNameFileOption();
                if (base.inputState.guessing == 0 && !newNameAllowed) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46062", fileDeclarationOption, TSqlParserResource.SQL46062Message);
                }
                goto IL_0173;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0173:
            return fileDeclarationOption;
        }

        public NameFileDeclarationOption nameFileOption() {
            NameFileDeclarationOption nameFileDeclarationOption = base.FragmentFactory.CreateFragment<NameFileDeclarationOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            IdentifierOrValueExpression logicalFileName = this.nonEmptyStringOrIdentifier();
            if (base.inputState.guessing == 0) {
                nameFileDeclarationOption.OptionKind = FileDeclarationOptionKind.Name;
                TSql80ParserBaseInternal.Match(token, "NAME");
                TSql80ParserBaseInternal.UpdateTokenInfo(nameFileDeclarationOption, token);
                nameFileDeclarationOption.LogicalFileName = logicalFileName;
                nameFileDeclarationOption.IsNewName = false;
            }
            return nameFileDeclarationOption;
        }

        public FileNameFileDeclarationOption fileNameFileOption() {
            FileNameFileDeclarationOption fileNameFileDeclarationOption = base.FragmentFactory.CreateFragment<FileNameFileDeclarationOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            Literal oSFileName = this.nonEmptyString();
            if (base.inputState.guessing == 0) {
                fileNameFileDeclarationOption.OptionKind = FileDeclarationOptionKind.FileName;
                TSql80ParserBaseInternal.Match(token, "FILENAME");
                TSql80ParserBaseInternal.UpdateTokenInfo(fileNameFileDeclarationOption, token);
                fileNameFileDeclarationOption.OSFileName = oSFileName;
            }
            return fileNameFileDeclarationOption;
        }

        public SizeFileDeclarationOption sizeFileOption() {
            SizeFileDeclarationOption sizeFileDeclarationOption = base.FragmentFactory.CreateFragment<SizeFileDeclarationOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            Literal size = this.integer();
            if (base.inputState.guessing == 0) {
                sizeFileDeclarationOption.OptionKind = FileDeclarationOptionKind.Size;
                TSql80ParserBaseInternal.Match(token, "SIZE");
                TSql80ParserBaseInternal.UpdateTokenInfo(sizeFileDeclarationOption, token);
                sizeFileDeclarationOption.Size = size;
            }
            switch (this.LA(1)) {
                case 232: {
                        MemoryUnit units = this.memUnit();
                        if (base.inputState.guessing == 0) {
                            sizeFileDeclarationOption.Units = units;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                case 198:
                    break;
            }
            return sizeFileDeclarationOption;
        }

        public MaxSizeFileDeclarationOption maxSizeFileOption() {
            MaxSizeFileDeclarationOption maxSizeFileDeclarationOption = base.FragmentFactory.CreateFragment<MaxSizeFileDeclarationOption>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "MAXSIZE");
                maxSizeFileDeclarationOption.OptionKind = FileDeclarationOptionKind.MaxSize;
                TSql80ParserBaseInternal.UpdateTokenInfo(maxSizeFileDeclarationOption, token);
            }
            switch (this.LA(1)) {
                case 221: {
                        Literal maxSize = this.integer();
                        if (base.inputState.guessing == 0) {
                            maxSizeFileDeclarationOption.MaxSize = maxSize;
                        }
                        switch (this.LA(1)) {
                            case 232: {
                                    MemoryUnit units = this.memUnit();
                                    if (base.inputState.guessing == 0) {
                                        maxSizeFileDeclarationOption.Units = units;
                                    }
                                    break;
                                }
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 192:
                            case 198:
                                break;
                        }
                        break;
                    }
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "UNLIMITED");
                        maxSizeFileDeclarationOption.Unlimited = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return maxSizeFileDeclarationOption;
        }

        public FileGrowthFileDeclarationOption fileGrowthFileOption() {
            FileGrowthFileDeclarationOption fileGrowthFileDeclarationOption = base.FragmentFactory.CreateFragment<FileGrowthFileDeclarationOption>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "FILEGROWTH");
                fileGrowthFileDeclarationOption.OptionKind = FileDeclarationOptionKind.FileGrowth;
                TSql80ParserBaseInternal.UpdateTokenInfo(fileGrowthFileDeclarationOption, token);
            }
            Literal growthIncrement = this.integer();
            if (base.inputState.guessing == 0) {
                fileGrowthFileDeclarationOption.GrowthIncrement = growthIncrement;
            }
            switch (this.LA(1)) {
                case 232: {
                        MemoryUnit units = this.memUnit();
                        if (base.inputState.guessing == 0) {
                            fileGrowthFileDeclarationOption.Units = units;
                        }
                        break;
                    }
                case 189:
                    token2 = this.LT(1);
                    this.match(189);
                    if (base.inputState.guessing == 0) {
                        fileGrowthFileDeclarationOption.Units = MemoryUnit.Percent;
                        TSql80ParserBaseInternal.UpdateTokenInfo(fileGrowthFileDeclarationOption, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                case 198:
                    break;
            }
            return fileGrowthFileDeclarationOption;
        }

        public NameFileDeclarationOption newNameFileOption() {
            NameFileDeclarationOption nameFileDeclarationOption = base.FragmentFactory.CreateFragment<NameFileDeclarationOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            IdentifierOrValueExpression logicalFileName = this.nonEmptyStringOrIdentifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "NEWNAME");
                nameFileDeclarationOption.OptionKind = FileDeclarationOptionKind.NewName;
                TSql80ParserBaseInternal.UpdateTokenInfo(nameFileDeclarationOption, token);
                nameFileDeclarationOption.LogicalFileName = logicalFileName;
                nameFileDeclarationOption.IsNewName = true;
            }
            return nameFileDeclarationOption;
        }

        public IdentifierOrValueExpression nonEmptyStringOrIdentifier() {
            IdentifierOrValueExpression identifierOrValueExpression = base.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            switch (this.LA(1)) {
                case 230:
                case 231: {
                        Literal valueExpression = this.nonEmptyString();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.Identifier = identifier;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierOrValueExpression;
        }

        public StringLiteral nonEmptyString() {
            StringLiteral stringLiteral = this.stringLiteral();
            if (base.inputState.guessing == 0 && (stringLiteral.Value == null || stringLiteral.Value.Length == 0)) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46063", stringLiteral, TSqlParserResource.SQL46063Message);
            }
            return stringLiteral;
        }

        public MemoryUnit memUnit() {
            MemoryUnit result = MemoryUnit.Unspecified;
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                result = MemoryUnitsHelper.Instance.ParseOption(token);
            }
            return result;
        }

        public IToken backupStart() {
            IToken result = null;
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 12:
                    token = this.LT(1);
                    this.match(12);
                    if (base.inputState.guessing == 0) {
                        result = token;
                    }
                    break;
                case 180:
                    token2 = this.LT(1);
                    this.match(180);
                    if (base.inputState.guessing == 0) {
                        result = token2;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public BackupStatement backupMain() {
            BackupStatement backupStatement = null;
            switch (this.LA(1)) {
                case 43:
                    return this.backupDatabase();
                case 153:
                case 154:
                case 232:
                    return this.backupTransactionLog();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void devList(TSqlFragment vParent, IList<DeviceInfo> deviceInfos) {
            DeviceInfo item = this.deviceInfo();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, deviceInfos, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.deviceInfo();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, deviceInfos, item);
                }
            }
        }

        public void backupOptions(BackupStatement vParent) {
            this.match(171);
            BackupOption item = this.backupOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.backupOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
                }
            }
        }

        public IToken restoreStart() {
            IToken result = null;
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 129:
                    token = this.LT(1);
                    this.match(129);
                    if (base.inputState.guessing == 0) {
                        result = token;
                    }
                    break;
                case 181:
                    token2 = this.LT(1);
                    this.match(181);
                    if (base.inputState.guessing == 0) {
                        result = token2;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public void restoreMain(RestoreStatement vParent) {
            IToken token = null;
            switch (this.LA(1)) {
                case 43: {
                        this.match(43);
                        IdentifierOrValueExpression databaseName = this.identifierOrVariable();
                        if (base.inputState.guessing == 0) {
                            vParent.DatabaseName = databaseName;
                            vParent.Kind = RestoreStatementKind.Database;
                            base.ThrowPartialAstIfPhaseOne(vParent);
                        }
                        this.restoreFileListOpt(vParent);
                        break;
                    }
                case 153:
                case 154: {
                        switch (this.LA(1)) {
                            case 154:
                                this.match(154);
                                break;
                            case 153:
                                this.match(153);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                        }
                        IdentifierOrValueExpression databaseName = this.identifierOrVariable();
                        if (base.inputState.guessing == 0) {
                            vParent.DatabaseName = databaseName;
                            vParent.Kind = RestoreStatementKind.TransactionLog;
                            base.ThrowPartialAstIfPhaseOne(vParent);
                        }
                        break;
                    }
                case 232: {
                        token = this.LT(1);
                        this.match(232);
                        IdentifierOrValueExpression databaseName = this.identifierOrVariable();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token, "LOG");
                            vParent.DatabaseName = databaseName;
                            vParent.Kind = RestoreStatementKind.TransactionLog;
                            base.ThrowPartialAstIfPhaseOne(vParent);
                        }
                        this.restoreFileListOpt(vParent);
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void restoreOptions(RestoreStatement vParent) {
            this.match(171);
            this.restoreOptionsList(vParent);
        }

        public BackupDatabaseStatement backupDatabase() {
            BackupDatabaseStatement backupDatabaseStatement = base.FragmentFactory.CreateFragment<BackupDatabaseStatement>();
            this.match(43);
            IdentifierOrValueExpression databaseName = this.identifierOrVariable();
            if (base.inputState.guessing == 0) {
                backupDatabaseStatement.DatabaseName = databaseName;
                base.ThrowPartialAstIfPhaseOne(backupDatabaseStatement);
            }
            this.backupFileListOpt(backupDatabaseStatement);
            return backupDatabaseStatement;
        }

        public BackupTransactionLogStatement backupTransactionLog() {
            BackupTransactionLogStatement backupTransactionLogStatement = base.FragmentFactory.CreateFragment<BackupTransactionLogStatement>();
            IToken token = null;
            switch (this.LA(1)) {
                case 154:
                    this.match(154);
                    break;
                case 153:
                    this.match(153);
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token, "LOG");
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            IdentifierOrValueExpression databaseName = this.identifierOrVariable();
            if (base.inputState.guessing == 0) {
                backupTransactionLogStatement.DatabaseName = databaseName;
                base.ThrowPartialAstIfPhaseOne(backupTransactionLogStatement);
            }
            return backupTransactionLogStatement;
        }

        public IdentifierOrValueExpression identifierOrVariable() {
            IdentifierOrValueExpression identifierOrValueExpression = base.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            switch (this.LA(1)) {
                case 234: {
                        ValueExpression valueExpression = this.variable();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.Identifier = identifier;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierOrValueExpression;
        }

        public void backupFileListOpt(BackupDatabaseStatement vParent) {
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        return;
                    case 65:
                        break;
                    default:
                        goto IL_02c9;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 151:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 232:
                        break;
                    default:
                        goto IL_02c9;
                }
            }
            BackupRestoreFileInfo item = this.backupRestoreFile();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Files, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.backupRestoreFile();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Files, item);
                }
            }
            return;
            IL_02c9:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public BackupRestoreFileInfo backupRestoreFile() {
            BackupRestoreFileInfo backupRestoreFileInfo = base.FragmentFactory.CreateFragment<BackupRestoreFileInfo>();
            IToken token = null;
            switch (this.LA(1)) {
                case 65:
                    this.LT(1);
                    this.match(65);
                    this.match(206);
                    if (base.inputState.guessing == 0) {
                        backupRestoreFileInfo.ItemKind = BackupRestoreItemKind.Files;
                    }
                    switch (this.LA(1)) {
                        case 230:
                        case 231:
                        case 234: {
                                ValueExpression item = this.stringOrVariable();
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(backupRestoreFileInfo, backupRestoreFileInfo.Items, item);
                                }
                                break;
                            }
                        case 191:
                            this.backupRestoreFileNameList(backupRestoreFileInfo);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    this.match(206);
                    switch (this.LA(1)) {
                        case 230:
                        case 231:
                        case 234: {
                                ValueExpression item = this.stringOrVariable();
                                if (base.inputState.guessing == 0) {
                                    if (TSql80ParserBaseInternal.TryMatch(token, "PAGE")) {
                                        backupRestoreFileInfo.ItemKind = BackupRestoreItemKind.Page;
                                    } else {
                                        TSql80ParserBaseInternal.Match(token, "FILEGROUP");
                                        backupRestoreFileInfo.ItemKind = BackupRestoreItemKind.FileGroups;
                                    }
                                    TSql80ParserBaseInternal.UpdateTokenInfo(backupRestoreFileInfo, token);
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(backupRestoreFileInfo, backupRestoreFileInfo.Items, item);
                                }
                                break;
                            }
                        case 191:
                            this.backupRestoreFileNameList(backupRestoreFileInfo);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.Match(token, "FILEGROUP");
                                backupRestoreFileInfo.ItemKind = BackupRestoreItemKind.FileGroups;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return backupRestoreFileInfo;
        }

        public void restoreFileListOpt(RestoreStatement vParent) {
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 71:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        return;
                    case 65:
                        break;
                    default:
                        goto IL_02c7;
                }
            } else {
                switch (num) {
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 232:
                        break;
                    default:
                        goto IL_02c7;
                }
            }
            BackupRestoreFileInfo item = this.backupRestoreFile();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Files, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.backupRestoreFile();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Files, item);
                }
            }
            return;
            IL_02c7:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ValueExpression stringOrVariable() {
            ValueExpression valueExpression = null;
            switch (this.LA(1)) {
                case 230:
                case 231:
                    return this.stringLiteral();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void backupRestoreFileNameList(BackupRestoreFileInfo vParent) {
            IToken token = null;
            this.LT(1);
            this.match(191);
            ValueExpression item = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Items, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.stringOrVariable();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Items, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public DeviceInfo deviceInfo() {
            DeviceInfo deviceInfo = base.FragmentFactory.CreateFragment<DeviceInfo>();
            IToken token = null;
            if (this.LA(1) >= 232 && this.LA(1) <= 234 && TSql80ParserInternal.tokenSet_19_.member(this.LA(2))) {
                IdentifierOrValueExpression logicalDevice = this.identifierOrVariable();
                if (base.inputState.guessing == 0) {
                    deviceInfo.LogicalDevice = logicalDevice;
                }
                goto IL_014d;
            }
            if ((this.LA(1) == 173 || this.LA(1) == 232) && this.LA(2) == 206) {
                switch (this.LA(1)) {
                    case 232:
                        token = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            deviceInfo.DeviceType = DeviceTypesHelper.Instance.ParseOption(token);
                        }
                        break;
                    case 173:
                        this.match(173);
                        if (base.inputState.guessing == 0) {
                            deviceInfo.DeviceType = DeviceType.Disk;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                this.match(206);
                ValueExpression physicalDevice = this.stringOrVariable();
                if (base.inputState.guessing == 0) {
                    deviceInfo.PhysicalDevice = physicalDevice;
                }
                goto IL_014d;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_014d:
            return deviceInfo;
        }

        public BackupOption backupOption() {
            BackupOption backupOption = base.FragmentFactory.CreateFragment<BackupOption>();
            IToken token = null;
            IToken token2 = null;
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                token = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    backupOption.OptionKind = BackupOptionsNoValueHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                    TSql80ParserBaseInternal.UpdateTokenInfo(backupOption, token);
                }
                goto IL_0150;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206) {
                token2 = this.LT(1);
                this.match(232);
                this.match(206);
                ScalarExpression value;
                switch (this.LA(1)) {
                    case 199:
                    case 221:
                    case 234:
                        value = this.signedIntegerOrVariable();
                        break;
                    case 230:
                    case 231:
                        value = this.stringLiteral();
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                if (base.inputState.guessing == 0) {
                    backupOption.OptionKind = BackupOptionsWithValueHelper.Instance.ParseOption(token2, SqlVersionFlags.TSql80);
                    backupOption.Value = value;
                }
                goto IL_0150;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0150:
            return backupOption;
        }

        public ScalarExpression signedIntegerOrVariable() {
            switch (this.LA(1)) {
                case 199:
                case 221:
                    return this.signedInteger();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public StringLiteral stringLiteral() {
            StringLiteral stringLiteral = base.FragmentFactory.CreateFragment<StringLiteral>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 230:
                    token = this.LT(1);
                    this.match(230);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(stringLiteral, token);
                        stringLiteral.Value = TSql80ParserBaseInternal.DecodeAsciiStringLiteral(token.getText());
                        stringLiteral.IsLargeObject = TSql80ParserBaseInternal.IsAsciiStringLob(stringLiteral.Value);
                    }
                    break;
                case 231:
                    token2 = this.LT(1);
                    this.match(231);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(stringLiteral, token2);
                        stringLiteral.IsNational = true;
                        stringLiteral.Value = TSql80ParserBaseInternal.DecodeUnicodeStringLiteral(token2.getText());
                        stringLiteral.IsLargeObject = TSql80ParserBaseInternal.IsUnicodeStringLob(stringLiteral.Value);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return stringLiteral;
        }

        public void restoreOptionsList(RestoreStatement vParent) {
            RestoreOption item = this.restoreOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.restoreOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
                }
            }
        }

        public RestoreOption restoreOption() {
            RestoreOption result = null;
            IToken token = null;
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                result = this.simpleRestoreOption();
                goto IL_0212;
            }
            if (this.LA(1) == 232 && this.LA(2) == 206) {
                token = this.LT(1);
                this.match(232);
                this.match(206);
                if ((this.LA(1) == 230 || this.LA(1) == 231 || this.LA(1) == 234) && this.LA(2) == 232 && TSql80ParserBaseInternal.IsStopAtBeforeMarkRestoreOption(token)) {
                    ValueExpression mark = this.stringOrVariable();
                    ValueExpression afterClause = this.afterClause();
                    if (base.inputState.guessing == 0) {
                        result = base.CreateStopRestoreOption(token, mark, afterClause);
                    }
                    goto IL_0212;
                }
                if (this.LA(1) != 199 && this.LA(1) != 221) {
                    if ((this.LA(1) == 230 || this.LA(1) == 231 || this.LA(1) == 234) && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                        ValueExpression mark = this.stringOrVariable();
                        if (base.inputState.guessing == 0) {
                            result = ((!TSql80ParserBaseInternal.IsStopAtBeforeMarkRestoreOption(token)) ? ((RestoreOption)base.CreateSimpleRestoreOptionWithValue(token, mark)) : ((RestoreOption)base.CreateStopRestoreOption(token, mark, null)));
                        }
                        goto IL_0212;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                ScalarExpression optionValue = this.signedInteger();
                if (base.inputState.guessing == 0) {
                    result = base.CreateSimpleRestoreOptionWithValue(token, optionValue);
                }
                goto IL_0212;
            }
            if (this.LA(1) == 232 && (this.LA(2) == 230 || this.LA(2) == 231 || this.LA(2) == 234)) {
                result = this.moveRestoreOption();
                goto IL_0212;
            }
            if (this.LA(1) == 65) {
                result = this.fileRestoreOption();
                goto IL_0212;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0212:
            return result;
        }

        public RestoreOption simpleRestoreOption() {
            RestoreOption restoreOption = base.FragmentFactory.CreateFragment<RestoreOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                restoreOption.OptionKind = RestoreOptionNoValueHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                TSql80ParserBaseInternal.UpdateTokenInfo(restoreOption, token);
            }
            return restoreOption;
        }

        public ValueExpression afterClause() {
            ValueExpression valueExpression = null;
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            valueExpression = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "AFTER");
            }
            return valueExpression;
        }

        public ScalarExpression signedInteger() {
            ScalarExpression result = null;
            IToken token = null;
            UnaryExpression unaryExpression = null;
            switch (this.LA(1)) {
                case 199:
                    token = this.LT(1);
                    this.match(199);
                    if (base.inputState.guessing == 0) {
                        unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                        TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token);
                        unaryExpression.UnaryExpressionType = UnaryExpressionType.Negative;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 221:
                    break;
            }
            Literal literal = this.integer();
            if (base.inputState.guessing == 0) {
                if (unaryExpression == null) {
                    result = literal;
                } else {
                    unaryExpression.Expression = literal;
                    result = unaryExpression;
                }
            }
            return result;
        }

        public MoveRestoreOption moveRestoreOption() {
            MoveRestoreOption moveRestoreOption = base.FragmentFactory.CreateFragment<MoveRestoreOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            ValueExpression logicalFileName = this.stringOrVariable();
            this.match(151);
            ValueExpression oSFileName = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "MOVE");
                moveRestoreOption.OptionKind = RestoreOptionKind.Move;
                moveRestoreOption.LogicalFileName = logicalFileName;
                moveRestoreOption.OSFileName = oSFileName;
            }
            return moveRestoreOption;
        }

        public ScalarExpressionRestoreOption fileRestoreOption() {
            ScalarExpressionRestoreOption scalarExpressionRestoreOption = base.FragmentFactory.CreateFragment<ScalarExpressionRestoreOption>();
            this.match(65);
            this.match(206);
            ScalarExpression value = this.signedIntegerOrVariable();
            if (base.inputState.guessing == 0) {
                scalarExpressionRestoreOption.OptionKind = RestoreOptionKind.File;
                scalarExpressionRestoreOption.Value = value;
            }
            return scalarExpressionRestoreOption;
        }

        public SchemaObjectName schemaObjectThreePartName() {
            SchemaObjectName schemaObjectName = base.FragmentFactory.CreateFragment<SchemaObjectName>();
            List<Identifier> otherCollection = this.identifierList(3);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(schemaObjectName, schemaObjectName.Identifiers, otherCollection);
            }
            return schemaObjectName;
        }

        public IdentifierOrValueExpression bulkInsertFrom() {
            IdentifierOrValueExpression result = null;
            switch (this.LA(1)) {
                case 221: {
                        Literal valueExpression = this.integer();
                        if (base.inputState.guessing == 0) {
                            result = base.IdentifierOrValueExpression(valueExpression);
                        }
                        break;
                    }
                case 230:
                case 231:
                case 232:
                case 233:
                    result = this.stringOrIdentifier();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public void bulkInsertOptions(BulkInsertStatement vParent) {
            IToken token = null;
            int num = 0;
            this.match(171);
            this.match(191);
            BulkInsertOption bulkInsertOption = this.bulkInsertOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)bulkInsertOption.OptionKind, bulkInsertOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, bulkInsertOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                bulkInsertOption = this.bulkInsertOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)bulkInsertOption.OptionKind, bulkInsertOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, bulkInsertOption);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public IdentifierOrValueExpression stringOrIdentifier() {
            IdentifierOrValueExpression identifierOrValueExpression = base.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            switch (this.LA(1)) {
                case 230:
                case 231: {
                        Literal valueExpression = this.stringLiteral();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.Identifier = identifier;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierOrValueExpression;
        }

        public BulkInsertOption bulkInsertOption() {
            BulkInsertOption bulkInsertOption = null;
            if (this.LA(1) == 113) {
                return this.bulkInsertSortOrderOption();
            }
            if (this.LA(1) == 232 && this.LA(2) == 206) {
                return this.simpleBulkInsertOptionWithValue();
            }
            if (this.LA(1) == 232 && (this.LA(2) == 192 || this.LA(2) == 198)) {
                return this.simpleBulkInsertOptionNoValue();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public OrderBulkInsertOption bulkInsertSortOrderOption() {
            OrderBulkInsertOption orderBulkInsertOption = base.FragmentFactory.CreateFragment<OrderBulkInsertOption>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(113);
            this.match(191);
            ColumnWithSortOrder item = this.columnWithSortOrder();
            if (base.inputState.guessing == 0) {
                orderBulkInsertOption.OptionKind = BulkInsertOptionKind.Order;
                TSql80ParserBaseInternal.UpdateTokenInfo(orderBulkInsertOption, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(orderBulkInsertOption, orderBulkInsertOption.Columns, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.columnWithSortOrder();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(orderBulkInsertOption, orderBulkInsertOption.Columns, item);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(orderBulkInsertOption, token2);
            }
            return orderBulkInsertOption;
        }

        public LiteralBulkInsertOption simpleBulkInsertOptionWithValue() {
            LiteralBulkInsertOption literalBulkInsertOption = base.FragmentFactory.CreateFragment<LiteralBulkInsertOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            switch (this.LA(1)) {
                case 221:
                case 222: {
                        Literal literal = this.integerOrNumeric();
                        if (base.inputState.guessing == 0) {
                            literalBulkInsertOption.OptionKind = BulkInsertIntOptionsHelper.Instance.ParseOption(token);
                            TSql80ParserBaseInternal.UpdateTokenInfo(literalBulkInsertOption, token);
                            literalBulkInsertOption.Value = literal;
                        }
                        break;
                    }
                case 230:
                case 231: {
                        Literal literal = this.stringLiteral();
                        if (base.inputState.guessing == 0) {
                            literalBulkInsertOption.OptionKind = BulkInsertStringOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                            if (literalBulkInsertOption.OptionKind == BulkInsertOptionKind.CodePage) {
                                TSql80ParserBaseInternal.MatchString(literal, "ACP", "OEM", "RAW");
                            } else if (literalBulkInsertOption.OptionKind == BulkInsertOptionKind.DataFileType) {
                                TSql80ParserBaseInternal.MatchString(literal, "CHAR", "NATIVE", "WIDECHAR", "WIDENATIVE", "WIDECHAR_ANSI", "DTS_BUFFERS");
                            }
                            TSql80ParserBaseInternal.UpdateTokenInfo(literalBulkInsertOption, token);
                            literalBulkInsertOption.Value = literal;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return literalBulkInsertOption;
        }

        public BulkInsertOption simpleBulkInsertOptionNoValue() {
            BulkInsertOption bulkInsertOption = base.FragmentFactory.CreateFragment<BulkInsertOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                bulkInsertOption.OptionKind = BulkInsertFlagOptionsHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(bulkInsertOption, token);
            }
            return bulkInsertOption;
        }

        public BulkInsertOption insertBulkOption() {
            BulkInsertOption bulkInsertOption = null;
            switch (this.LA(1)) {
                case 113:
                    return this.bulkInsertSortOrderOption();
                case 232:
                    return this.simpleInsertBulkOption();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public BulkInsertOption simpleInsertBulkOption() {
            BulkInsertOption bulkInsertOption = null;
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            switch (this.LA(1)) {
                case 206: {
                        this.match(206);
                        Literal value = this.integerOrNumeric();
                        if (base.inputState.guessing == 0) {
                            LiteralBulkInsertOption literalBulkInsertOption = base.FragmentFactory.CreateFragment<LiteralBulkInsertOption>();
                            TSql80ParserBaseInternal.UpdateTokenInfo(literalBulkInsertOption, token);
                            if (TSql80ParserBaseInternal.TryMatch(token, "ROWS_PER_BATCH")) {
                                literalBulkInsertOption.OptionKind = BulkInsertOptionKind.RowsPerBatch;
                            } else {
                                TSql80ParserBaseInternal.Match(token, "KILOBYTES_PER_BATCH");
                                literalBulkInsertOption.OptionKind = BulkInsertOptionKind.KilobytesPerBatch;
                            }
                            literalBulkInsertOption.Value = value;
                            bulkInsertOption = literalBulkInsertOption;
                        }
                        break;
                    }
                case 192:
                case 198:
                    if (base.inputState.guessing != 0) {
                        break;
                    }
                    bulkInsertOption = base.FragmentFactory.CreateFragment<BulkInsertOption>();
                    bulkInsertOption.OptionKind = BulkInsertFlagOptionsHelper.Instance.ParseOption(token);
                    TSql80ParserBaseInternal.UpdateTokenInfo(bulkInsertOption, token);
                    if (bulkInsertOption.OptionKind != BulkInsertOptionKind.KeepIdentity) {
                        break;
                    }
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return bulkInsertOption;
        }

        public Literal integerOrNumeric() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 222:
                    return this.numeric();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void coldefList(InsertBulkStatement vParent) {
            IToken token = null;
            this.match(191);
            InsertBulkColumnDefinition item = this.coldefItem();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.ColumnDefinitions, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.coldefItem();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.ColumnDefinitions, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public void insertBulkOptions(InsertBulkStatement vParent) {
            IToken token = null;
            int num = 0;
            this.match(171);
            this.match(191);
            BulkInsertOption bulkInsertOption = this.insertBulkOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)bulkInsertOption.OptionKind, bulkInsertOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, bulkInsertOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                bulkInsertOption = this.insertBulkOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)bulkInsertOption.OptionKind, bulkInsertOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, bulkInsertOption);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public InsertBulkColumnDefinition coldefItem() {
            InsertBulkColumnDefinition insertBulkColumnDefinition = base.FragmentFactory.CreateFragment<InsertBulkColumnDefinition>();
            ColumnDefinitionBase column = this.columnDefinitionEx();
            if (base.inputState.guessing == 0) {
                insertBulkColumnDefinition.Column = column;
            }
            switch (this.LA(1)) {
                case 99:
                case 100: {
                        bool flag = this.nullNotNull(insertBulkColumnDefinition);
                        if (base.inputState.guessing == 0) {
                            insertBulkColumnDefinition.NullNotNull = (NullNotNull)(flag ? 1 : 2);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                case 198:
                    break;
            }
            return insertBulkColumnDefinition;
        }

        public ColumnDefinitionBase columnDefinitionEx() {
            ColumnDefinitionBase columnDefinitionBase = null;
            IToken token = null;
            if ((this.LA(1) == 232 || this.LA(1) == 233) && TSql80ParserInternal.tokenSet_22_.member(this.LA(2))) {
                columnDefinitionBase = this.columnDefinitionBasic();
                goto IL_00d1;
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_23_.member(this.LA(2))) {
                token = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token, "TIMESTAMP");
                    columnDefinitionBase = base.FragmentFactory.CreateFragment<ColumnDefinitionBase>();
                    Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
                    TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
                    identifier.SetUnquotedIdentifier("TIMESTAMP");
                    columnDefinitionBase.ColumnIdentifier = identifier;
                }
                goto IL_00d1;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00d1:
            return columnDefinitionBase;
        }

        public bool nullNotNull(TSqlFragment vParent) {
            bool result = true;
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 99:
                    token = this.LT(1);
                    this.match(99);
                    if (base.inputState.guessing == 0) {
                        result = false;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 100:
                    break;
            }
            token2 = this.LT(1);
            this.match(100);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
            return result;
        }

        public ColumnWithSortOrder columnWithSortOrder() {
            ColumnWithSortOrder columnWithSortOrder = base.FragmentFactory.CreateFragment<ColumnWithSortOrder>();
            ColumnReferenceExpression column = this.identifierColumnReferenceExpression();
            if (base.inputState.guessing == 0) {
                columnWithSortOrder.Column = column;
            }
            switch (this.LA(1)) {
                case 10:
                case 50: {
                        SortOrder sortOrder = this.orderByOption(columnWithSortOrder);
                        if (base.inputState.guessing == 0) {
                            columnWithSortOrder.SortOrder = sortOrder;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                case 198:
                    break;
            }
            return columnWithSortOrder;
        }

        public void dbccNamedLiteralList(DbccStatement vParent) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234: {
                        DbccNamedLiteral item = this.dbccNamedLiteral();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Literals, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.dbccNamedLiteral();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Literals, item);
                            }
                        }
                        break;
                    }
                case 192:
                    if (base.inputState.guessing == 0) {
                        vParent.ParenthesisRequired = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
        }

        public void dbccOptions(DbccStatement vParent) {
            this.match(171);
            this.dbccOptionsList(vParent);
        }

        public void dbccOptionsList(DbccStatement vParent) {
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                this.dbccOptionsListItems(vParent);
                return;
            }
            if (this.LA(1) == 232 && this.LA(2) == 90) {
                this.dbccOptionsJoin(vParent);
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void dbccOptionsListItems(DbccStatement vParent) {
            DbccOption item = this.dbccOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.dbccOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
                }
            }
        }

        public void dbccOptionsJoin(DbccStatement vParent) {
            DbccOption item = this.dbccJoinOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
            }
            int num = 0;
            while (true) {
                if (this.LA(1) != 90) {
                    break;
                }
                this.match(90);
                item = this.dbccJoinOption();
                if (base.inputState.guessing == 0) {
                    vParent.OptionsUseJoin = true;
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, item);
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public DbccOption dbccOption() {
            DbccOption dbccOption = base.FragmentFactory.CreateFragment<DbccOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                dbccOption.OptionKind = DbccOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                TSql80ParserBaseInternal.UpdateTokenInfo(dbccOption, token);
            }
            return dbccOption;
        }

        public DbccOption dbccJoinOption() {
            DbccOption dbccOption = base.FragmentFactory.CreateFragment<DbccOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                dbccOption.OptionKind = DbccJoinOptionsHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(dbccOption, token);
            }
            return dbccOption;
        }

        public DbccNamedLiteral dbccNamedLiteral() {
            DbccNamedLiteral dbccNamedLiteral = base.FragmentFactory.CreateFragment<DbccNamedLiteral>();
            IToken token = null;
            if (this.LA(1) == 232 && this.LA(2) == 206) {
                token = this.LT(1);
                this.match(232);
                this.match(206);
                if (base.inputState.guessing == 0) {
                    dbccNamedLiteral.Name = token.getText();
                    TSql80ParserBaseInternal.UpdateTokenInfo(dbccNamedLiteral, token);
                }
                goto IL_00a3;
            }
            if (TSql80ParserInternal.tokenSet_24_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_25_.member(this.LA(2))) {
                goto IL_00a3;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00a3:
            ScalarExpression value = this.possibleNegativeConstantOrIdentifier();
            if (base.inputState.guessing == 0) {
                dbccNamedLiteral.Value = value;
            }
            return dbccNamedLiteral;
        }

        public void authorizationOpt(IAuthorization vParent) {
            switch (this.LA(1)) {
                case 1:
                case 35:
                case 75:
                case 219:
                    break;
                case 11:
                    this.authorization(vParent);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void authorization(IAuthorization vParent) {
            this.match(11);
            Identifier owner = this.identifier();
            if (base.inputState.guessing == 0) {
                vParent.Owner = owner;
            }
        }

        public StatementList createSchemaElementList() {
            StatementList statementList = base.FragmentFactory.CreateFragment<StatementList>();
            while (true) {
                if (this.LA(1) != 35 && this.LA(1) != 75) {
                    break;
                }
                TSqlStatement item = this.createSchemaElement();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(statementList, statementList.Statements, item);
                }
            }
            return statementList;
        }

        public TSqlStatement createSchemaElement() {
            TSqlStatement tSqlStatement = null;
            if (this.LA(1) == 35 && this.LA(2) == 166) {
                return this.createViewStatement();
            }
            if (this.LA(1) == 35 && this.LA(2) == 148) {
                return this.createTableStatement();
            }
            if (this.LA(1) == 75) {
                return this.grantStatement80();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void functionStatementBody(FunctionStatementBody vResult, out bool vParseErrorOccurred) {
            IToken token = null;
            this.match(73);
            SchemaObjectName name = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(name, "TRIGGER");
                vResult.Name = name;
                TSql80ParserBaseInternal.CheckForTemporaryFunction(name);
                base.ThrowPartialAstIfPhaseOne(vResult);
            }
            this.match(191);
            switch (this.LA(1)) {
                case 234:
                    this.functionParameterList(vResult);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            this.match(192);
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "RETURNS");
            }
            this.functionReturnTypeAndBody(vResult, out vParseErrorOccurred);
        }

        public void functionParameterList(FunctionStatementBody vResult) {
            ProcedureParameter item = this.functionParameter();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Parameters, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.functionParameter();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Parameters, item);
                }
            }
        }

        public void functionReturnTypeAndBody(FunctionStatementBody vParent, out bool vParseErrorOccurred) {
            vParseErrorOccurred = false;
            switch (this.LA(1)) {
                case 53:
                case 96:
                case 232:
                case 233: {
                        DataTypeReference dataType = this.scalarDataType();
                        if (base.inputState.guessing == 0) {
                            ScalarFunctionReturnType scalarFunctionReturnType = base.FragmentFactory.CreateFragment<ScalarFunctionReturnType>();
                            scalarFunctionReturnType.DataType = dataType;
                            vParent.ReturnType = scalarFunctionReturnType;
                        }
                        switch (this.LA(1)) {
                            case 171:
                                this.functionAttributes(vParent);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 9:
                            case 13:
                                break;
                        }
                        switch (this.LA(1)) {
                            case 9:
                                this.match(9);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 13:
                                break;
                        }
                        BeginEndBlockStatement beginEndBlockStatement = this.beginEndBlockStatement();
                        if (base.inputState.guessing == 0) {
                            base.SetFunctionBodyStatement(vParent, beginEndBlockStatement);
                            vParseErrorOccurred = (beginEndBlockStatement == null);
                        }
                        break;
                    }
                case 148: {
                        this.match(148);
                        switch (this.LA(1)) {
                            case 171:
                                this.functionAttributes(vParent);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 9:
                            case 131:
                                break;
                        }
                        switch (this.LA(1)) {
                            case 9:
                                this.match(9);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 131:
                                break;
                        }
                        this.match(131);
                        SelectFunctionReturnType returnType = this.functionReturnClauseRelational();
                        if (base.inputState.guessing == 0) {
                            vParent.ReturnType = returnType;
                        }
                        break;
                    }
                case 234: {
                        DeclareTableVariableBody declareTableVariableBody = this.declareTableBody(IndexAffectingStatement.CreateOrAlterFunction);
                        if (base.inputState.guessing == 0) {
                            TableValuedFunctionReturnType tableValuedFunctionReturnType = base.FragmentFactory.CreateFragment<TableValuedFunctionReturnType>();
                            tableValuedFunctionReturnType.DeclareTableVariableBody = declareTableVariableBody;
                            vParent.ReturnType = tableValuedFunctionReturnType;
                        }
                        switch (this.LA(1)) {
                            case 171:
                                this.functionAttributes(vParent);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 9:
                            case 13:
                                break;
                        }
                        switch (this.LA(1)) {
                            case 9:
                                this.match(9);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 13:
                                break;
                        }
                        BeginEndBlockStatement beginEndBlockStatement = this.beginEndBlockStatement();
                        if (base.inputState.guessing == 0) {
                            base.SetFunctionBodyStatement(vParent, beginEndBlockStatement);
                            vParseErrorOccurred = (beginEndBlockStatement == null);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ProcedureParameter functionParameter() {
            ProcedureParameter procedureParameter = base.FragmentFactory.CreateFragment<ProcedureParameter>();
            Identifier variableName = this.identifierVariable();
            switch (this.LA(1)) {
                case 9:
                    this.match(9);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 53:
                case 96:
                case 232:
                case 233:
                    break;
            }
            if (base.inputState.guessing == 0) {
                procedureParameter.VariableName = variableName;
            }
            this.scalarProcedureParameter(procedureParameter, false);
            return procedureParameter;
        }

        public Identifier identifierVariable() {
            Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
            IToken token = null;
            token = this.LT(1);
            this.match(234);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
                identifier.SetIdentifier(token.getText());
            }
            return identifier;
        }

        public void scalarProcedureParameter(ProcedureParameter vParent, bool outputAllowed) {
            IToken token = null;
            DataTypeReference dataType = this.scalarDataType();
            if (base.inputState.guessing == 0) {
                vParent.DataType = dataType;
            }
            switch (this.LA(1)) {
                case 206: {
                        this.match(206);
                        ScalarExpression value = this.possibleNegativeConstantOrIdentifierWithDefault();
                        if (base.inputState.guessing == 0) {
                            vParent.Value = value;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 9:
                case 67:
                case 171:
                case 192:
                case 198:
                case 232:
                    break;
            }
            switch (this.LA(1)) {
                case 9:
                case 67:
                case 171:
                case 192:
                case 198:
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                        TSql80ParserBaseInternal.Match(token, "OUTPUT", "OUT");
                        if (outputAllowed) {
                            vParent.Modifier = ParameterModifier.Output;
                        } else {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46039", token, TSqlParserResource.SQL46039Message);
                        }
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void functionAttributes(FunctionStatementBody vParent) {
            int num = 0;
            this.match(171);
            FunctionOption functionOption = this.functionAttribute();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)functionOption.OptionKind, functionOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, functionOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                functionOption = this.functionAttribute();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)functionOption.OptionKind, functionOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, functionOption);
                }
            }
        }

        public BeginEndBlockStatement beginEndBlockStatement() {
            BeginEndBlockStatement beginEndBlockStatement = base.FragmentFactory.CreateFragment<BeginEndBlockStatement>();
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            StatementList statementList = base.FragmentFactory.CreateFragment<StatementList>();
            token = this.LT(1);
            this.match(13);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(beginEndBlockStatement, token);
            }
            int num = 0;
            while (true) {
                if (!TSql80ParserInternal.tokenSet_3_.member(this.LA(1))) {
                    break;
                }
                TSqlStatement tSqlStatement = this.statementOptSemi();
                if (base.inputState.guessing == 0) {
                    if (tSqlStatement != null) {
                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(statementList, statementList.Statements, tSqlStatement);
                    } else {
                        flag = true;
                        base.ThrowIfEndOfFileOrBatch();
                    }
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token2 = this.LT(1);
            this.match(56);
            if (base.inputState.guessing == 0) {
                beginEndBlockStatement.StatementList = statementList;
                TSql80ParserBaseInternal.UpdateTokenInfo(beginEndBlockStatement, token2);
                if (flag) {
                    beginEndBlockStatement = null;
                }
            }
            return beginEndBlockStatement;
        }

        public SelectFunctionReturnType functionReturnClauseRelational() {
            SelectFunctionReturnType selectFunctionReturnType = base.FragmentFactory.CreateFragment<SelectFunctionReturnType>();
            SelectStatement selectStatement = this.subqueryExpressionAsStatement();
            if (base.inputState.guessing == 0) {
                selectFunctionReturnType.SelectStatement = selectStatement;
            }
            return selectFunctionReturnType;
        }

        public DeclareTableVariableBody declareTableBody(IndexAffectingStatement statementType) {
            bool asDefined = false;
            Identifier variableName = this.identifierVariable();
            this.match(148);
            DeclareTableVariableBody declareTableVariableBody = this.declareTableBodyMain(statementType);
            if (base.inputState.guessing == 0) {
                declareTableVariableBody.VariableName = variableName;
                declareTableVariableBody.AsDefined = asDefined;
            }
            return declareTableVariableBody;
        }

        public FunctionOption functionAttribute() {
            FunctionOption functionOption = base.FragmentFactory.CreateFragment<FunctionOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_26_.member(this.LA(2))) {
                token = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    functionOption.OptionKind = TSql80ParserBaseInternal.ParseAlterCreateFunctionWithOption(token);
                    TSql80ParserBaseInternal.UpdateTokenInfo(functionOption, token);
                }
                goto IL_01a1;
            }
            if (this.LA(1) == 232 && this.LA(2) == 100) {
                token2 = this.LT(1);
                this.match(232);
                this.match(100);
                this.match(105);
                this.match(100);
                token3 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token2, "RETURNS");
                    TSql80ParserBaseInternal.Match(token3, "INPUT");
                    functionOption.OptionKind = FunctionOptionKind.ReturnsNullOnNullInput;
                    TSql80ParserBaseInternal.UpdateTokenInfo(functionOption, token3);
                }
                goto IL_01a1;
            }
            if (this.LA(1) == 232 && this.LA(2) == 105) {
                token4 = this.LT(1);
                this.match(232);
                this.match(105);
                this.match(100);
                token5 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token4, "CALLED");
                    TSql80ParserBaseInternal.Match(token5, "INPUT");
                    functionOption.OptionKind = FunctionOptionKind.CalledOnNullInput;
                    TSql80ParserBaseInternal.UpdateTokenInfo(functionOption, token5);
                }
                goto IL_01a1;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_01a1:
            return functionOption;
        }

        public void identifierColumnList(TSqlFragment vParent, IList<ColumnReferenceExpression> columns) {
            IToken token = null;
            this.match(191);
            ColumnReferenceExpression item = this.identifierColumnReferenceExpression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, columns, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.identifierColumnReferenceExpression();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, columns, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public StatisticsOption createStatisticsStatementWithOption(ref bool isConflictingOption) {
            if (this.LA(1) == 232 && this.LA(2) == 221) {
                return this.sampleStatisticsOption(ref isConflictingOption);
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                return this.simpleStatisticsOption(ref isConflictingOption);
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public LiteralStatisticsOption sampleStatisticsOption(ref bool isConflictingOption) {
            LiteralStatisticsOption literalStatisticsOption = base.FragmentFactory.CreateFragment<LiteralStatisticsOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(232);
            Literal literal = this.integer();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "SAMPLE");
                if (isConflictingOption) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46071", token, TSqlParserResource.SQL46071Message);
                } else {
                    isConflictingOption = true;
                }
                literalStatisticsOption.Literal = literal;
            }
            switch (this.LA(1)) {
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(literalStatisticsOption, token2);
                        literalStatisticsOption.OptionKind = TSql80ParserBaseInternal.ParseSampleOptionsWithOption(token2);
                    }
                    break;
                case 116:
                    token3 = this.LT(1);
                    this.match(116);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(literalStatisticsOption, token3);
                        literalStatisticsOption.OptionKind = StatisticsOptionKind.SamplePercent;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return literalStatisticsOption;
        }

        public StatisticsOption simpleStatisticsOption(ref bool isConflictingOption) {
            StatisticsOption statisticsOption = base.FragmentFactory.CreateFragment<StatisticsOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(statisticsOption, token);
                if (TSql80ParserBaseInternal.TryMatch(token, "ROWS")) {
                    statisticsOption.OptionKind = StatisticsOptionKind.Rows;
                    if (isConflictingOption) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46071", token, TSqlParserResource.SQL46071Message);
                    } else {
                        isConflictingOption = true;
                    }
                } else {
                    if (TSql80ParserBaseInternal.TryMatch(token, "FULLSCAN")) {
                        if (isConflictingOption) {
                            TSql80ParserBaseInternal.ThrowParseErrorException("SQL46071", token, TSqlParserResource.SQL46071Message);
                        } else {
                            isConflictingOption = true;
                        }
                    }
                    statisticsOption.OptionKind = TSql80ParserBaseInternal.ParseCreateStatisticsWithOption(token);
                }
            }
            return statisticsOption;
        }

        public void columnNameList(TSqlFragment vParent, IList<Identifier> columnNames) {
            IToken token = null;
            this.match(191);
            Identifier item = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, columnNames, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, columnNames, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public StatisticsOption updateStatisticsStatementWithOption(ref bool isConflictingOption) {
            if (this.LA(1) == 232 && this.LA(2) == 221) {
                return this.sampleStatisticsOption(ref isConflictingOption);
            }
            if ((this.LA(1) == 135 || this.LA(1) == 232) && this.LA(2) == 206) {
                return this.updateStatisticsLiteralOption();
            }
            if ((this.LA(1) == 5 || this.LA(1) == 84 || this.LA(1) == 232) && TSql80ParserInternal.tokenSet_21_.member(this.LA(2))) {
                return this.updateStatisticsSimpleOption(ref isConflictingOption);
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public LiteralStatisticsOption updateStatisticsLiteralOption() {
            LiteralStatisticsOption literalStatisticsOption = base.FragmentFactory.CreateFragment<LiteralStatisticsOption>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 232: {
                        token = this.LT(1);
                        this.match(232);
                        this.match(206);
                        Literal literal = this.integer();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token, "PAGECOUNT");
                            literalStatisticsOption.OptionKind = StatisticsOptionKind.PageCount;
                            TSql80ParserBaseInternal.UpdateTokenInfo(literalStatisticsOption, token);
                            literalStatisticsOption.Literal = literal;
                        }
                        break;
                    }
                case 135: {
                        token2 = this.LT(1);
                        this.match(135);
                        this.match(206);
                        Literal literal = this.integer();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(literalStatisticsOption, token2);
                            literalStatisticsOption.OptionKind = StatisticsOptionKind.RowCount;
                            literalStatisticsOption.Literal = literal;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return literalStatisticsOption;
        }

        public StatisticsOption updateStatisticsSimpleOption(ref bool isConflictingOption) {
            StatisticsOption statisticsOption = base.FragmentFactory.CreateFragment<StatisticsOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(statisticsOption, token);
                        if (TSql80ParserBaseInternal.TryMatch(token, "ROWS")) {
                            statisticsOption.OptionKind = StatisticsOptionKind.Rows;
                            if (isConflictingOption) {
                                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46071", token, TSqlParserResource.SQL46071Message);
                            } else {
                                isConflictingOption = true;
                            }
                        } else {
                            if (TSql80ParserBaseInternal.TryMatch(token, "FULLSCAN")) {
                                if (isConflictingOption) {
                                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46071", token, TSqlParserResource.SQL46071Message);
                                } else {
                                    isConflictingOption = true;
                                }
                            }
                            statisticsOption.OptionKind = StatisticsOptionHelper.Instance.ParseOption(token);
                        }
                    }
                    break;
                case 5:
                    token2 = this.LT(1);
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(statisticsOption, token2);
                        statisticsOption.OptionKind = StatisticsOptionKind.All;
                    }
                    break;
                case 84:
                    token3 = this.LT(1);
                    this.match(84);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(statisticsOption, token3);
                        statisticsOption.OptionKind = StatisticsOptionKind.Index;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return statisticsOption;
        }

        public SecurityElement80 securityElement80() {
            SecurityElement80 securityElement = null;
            if (this.LA(1) == 5 && (this.LA(2) == 71 || this.LA(2) == 151)) {
                return this.commandSecurityElementAll80();
            }
            if (this.LA(1) != 12 && this.LA(1) != 35) {
                if (TSql80ParserInternal.tokenSet_27_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_28_.member(this.LA(2))) {
                    return this.privilegeSecurityElement80();
                }
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return this.commandSecurityElement80();
        }

        public SecurityUserClause80 securityUserClause80() {
            SecurityUserClause80 securityUserClause = base.FragmentFactory.CreateFragment<SecurityUserClause80>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 122:
                    token = this.LT(1);
                    this.match(122);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(securityUserClause, token);
                        securityUserClause.UserType80 = UserType80.Public;
                    }
                    break;
                case 100:
                    token2 = this.LT(1);
                    this.match(100);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(securityUserClause, token2);
                        securityUserClause.UserType80 = UserType80.Null;
                    }
                    break;
                case 232:
                case 233: {
                        Identifier item = this.identifier();
                        if (base.inputState.guessing == 0) {
                            securityUserClause.UserType80 = UserType80.Users;
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(securityUserClause, securityUserClause.Users, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.identifier();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(securityUserClause, securityUserClause.Users, item);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return securityUserClause;
        }

        public CommandSecurityElement80 commandSecurityElementAll80() {
            CommandSecurityElement80 commandSecurityElement = base.FragmentFactory.CreateFragment<CommandSecurityElement80>();
            IToken token = null;
            token = this.LT(1);
            this.match(5);
            if (base.inputState.guessing == 0) {
                commandSecurityElement.All = true;
                TSql80ParserBaseInternal.UpdateTokenInfo(commandSecurityElement, token);
            }
            return commandSecurityElement;
        }

        public CommandSecurityElement80 commandSecurityElement80() {
            CommandSecurityElement80 commandSecurityElement = base.FragmentFactory.CreateFragment<CommandSecurityElement80>();
            this.command80(commandSecurityElement);
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                this.command80(commandSecurityElement);
            }
            return commandSecurityElement;
        }

        public PrivilegeSecurityElement80 privilegeSecurityElement80() {
            PrivilegeSecurityElement80 privilegeSecurityElement = base.FragmentFactory.CreateFragment<PrivilegeSecurityElement80>();
            Privilege80 item = this.privilege80();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(privilegeSecurityElement, privilegeSecurityElement.Privileges, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.privilege80();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(privilegeSecurityElement, privilegeSecurityElement.Privileges, item);
                }
            }
            this.match(105);
            SchemaObjectName schemaObjectName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                privilegeSecurityElement.SchemaObjectName = schemaObjectName;
            }
            switch (this.LA(1)) {
                case 191:
                    this.columnNameList(privilegeSecurityElement, privilegeSecurityElement.Columns);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 71:
                case 151:
                    break;
            }
            return privilegeSecurityElement;
        }

        public void command80(CommandSecurityElement80 vParent) {
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            IToken token6 = null;
            IToken token7 = null;
            IToken token8 = null;
            IToken token9 = null;
            IToken token10 = null;
            IToken token11 = null;
            IToken token12 = null;
            switch (this.LA(1)) {
                case 35:
                    token = this.LT(1);
                    this.match(35);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    switch (this.LA(1)) {
                        case 43:
                            token2 = this.LT(1);
                            this.match(43);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                                vParent.CommandOptions |= CommandOptions.CreateDatabase;
                            }
                            break;
                        case 47:
                            token3 = this.LT(1);
                            this.match(47);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token3);
                                vParent.CommandOptions |= CommandOptions.CreateDefault;
                            }
                            break;
                        case 73:
                            token4 = this.LT(1);
                            this.match(73);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token4);
                                vParent.CommandOptions |= CommandOptions.CreateFunction;
                            }
                            break;
                        case 121:
                            token5 = this.LT(1);
                            this.match(121);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token5);
                                vParent.CommandOptions |= CommandOptions.CreateProcedure;
                            }
                            break;
                        case 120:
                            token6 = this.LT(1);
                            this.match(120);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token6);
                                vParent.CommandOptions |= CommandOptions.CreateProcedure;
                            }
                            break;
                        case 137:
                            token7 = this.LT(1);
                            this.match(137);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token7);
                                vParent.CommandOptions |= CommandOptions.CreateRule;
                            }
                            break;
                        case 148:
                            token8 = this.LT(1);
                            this.match(148);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token8);
                                vParent.CommandOptions |= CommandOptions.CreateTable;
                            }
                            break;
                        case 166:
                            token9 = this.LT(1);
                            this.match(166);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token9);
                                vParent.CommandOptions |= CommandOptions.CreateView;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                case 12:
                    token10 = this.LT(1);
                    this.match(12);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token10);
                    }
                    switch (this.LA(1)) {
                        case 43:
                            token11 = this.LT(1);
                            this.match(43);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token11);
                                vParent.CommandOptions |= CommandOptions.BackupDatabase;
                            }
                            break;
                        case 232:
                            token12 = this.LT(1);
                            this.match(232);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token12);
                                TSql80ParserBaseInternal.Match(token12, "LOG");
                                vParent.CommandOptions |= CommandOptions.BackupLog;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public Privilege80 privilege80() {
            Privilege80 privilege = base.FragmentFactory.CreateFragment<Privilege80>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            IToken token6 = null;
            IToken token7 = null;
            IToken token8 = null;
            IToken token9 = null;
            switch (this.LA(1)) {
                case 5:
                    token = this.LT(1);
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token);
                        privilege.PrivilegeType80 = PrivilegeType80.All;
                    }
                    switch (this.LA(1)) {
                        case 232:
                            token2 = this.LT(1);
                            this.match(232);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.Match(token2, "PRIVILEGES");
                                TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token2);
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 105:
                        case 191:
                        case 198:
                            break;
                    }
                    break;
                case 140:
                    token3 = this.LT(1);
                    this.match(140);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token3);
                        privilege.PrivilegeType80 = PrivilegeType80.Select;
                    }
                    break;
                case 86:
                    token4 = this.LT(1);
                    this.match(86);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token4);
                        privilege.PrivilegeType80 = PrivilegeType80.Insert;
                    }
                    break;
                case 48:
                    token5 = this.LT(1);
                    this.match(48);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token5);
                        privilege.PrivilegeType80 = PrivilegeType80.Delete;
                    }
                    break;
                case 160:
                    token6 = this.LT(1);
                    this.match(160);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token6);
                        privilege.PrivilegeType80 = PrivilegeType80.Update;
                    }
                    break;
                case 61:
                    token7 = this.LT(1);
                    this.match(61);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token7);
                        privilege.PrivilegeType80 = PrivilegeType80.Execute;
                    }
                    break;
                case 60:
                    token8 = this.LT(1);
                    this.match(60);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token8);
                        privilege.PrivilegeType80 = PrivilegeType80.Execute;
                    }
                    break;
                case 127:
                    token9 = this.LT(1);
                    this.match(127);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(privilege, token9);
                        privilege.PrivilegeType80 = PrivilegeType80.References;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            switch (this.LA(1)) {
                case 191:
                    this.columnNameList(privilege, privilege.Columns);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 105:
                case 198:
                    break;
            }
            return privilege;
        }

        public ColumnReferenceExpression column() {
            ColumnReferenceExpression columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            columnReferenceExpression.ColumnType = ColumnType.Regular;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        MultiPartIdentifier multiPartIdentifier = this.multiPartIdentifier(-1);
                        if (base.inputState.guessing == 0) {
                            columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
                        }
                        int num = this.LA(1);
                        if (num <= 95) {
                            switch (num) {
                                case 1:
                                case 6:
                                case 12:
                                case 13:
                                case 15:
                                case 17:
                                case 22:
                                case 23:
                                case 28:
                                case 33:
                                case 35:
                                case 44:
                                case 45:
                                case 46:
                                case 48:
                                case 49:
                                case 54:
                                case 55:
                                case 56:
                                case 60:
                                case 61:
                                case 64:
                                case 74:
                                case 75:
                                case 82:
                                case 86:
                                case 92:
                                case 95:
                                    goto end_IL_0000;
                            }
                        } else {
                            switch (num) {
                                case 200:
                                    this.match(200);
                                    this.specialColumn(columnReferenceExpression);
                                    goto end_IL_0000;
                                case 106:
                                case 111:
                                case 119:
                                case 123:
                                case 125:
                                case 126:
                                case 129:
                                case 131:
                                case 132:
                                case 134:
                                case 138:
                                case 140:
                                case 142:
                                case 143:
                                case 144:
                                case 156:
                                case 160:
                                case 161:
                                case 162:
                                case 167:
                                case 170:
                                case 172:
                                case 173:
                                case 176:
                                case 180:
                                case 181:
                                case 191:
                                case 192:
                                case 198:
                                case 204:
                                case 219:
                                case 220:
                                case 221:
                                case 224:
                                case 234:
                                    goto end_IL_0000;
                            }
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 81:
                case 136:
                case 227:
                    this.specialColumn(columnReferenceExpression);
                    break;
                default: {
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    end_IL_0000:
                    break;
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckSpecialColumn(columnReferenceExpression);
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(columnReferenceExpression, false);
            }
            return columnReferenceExpression;
        }

        public ValueExpression binaryOrVariable() {
            switch (this.LA(1)) {
                case 224:
                    return this.binary();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ValueExpression integerOrVariable() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void modificationTextStatement(TextModificationStatement vParent) {
            IToken token = null;
            switch (this.LA(1)) {
                case 17:
                    this.match(17);
                    if (base.inputState.guessing == 0) {
                        vParent.Bulk = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 81:
                case 136:
                case 200:
                case 227:
                case 232:
                case 233:
                    break;
            }
            ColumnReferenceExpression column = this.column();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(column, true);
                vParent.Column = column;
            }
            ValueExpression textId;
            switch (this.LA(1)) {
                case 224:
                case 234:
                    textId = this.binaryOrVariable();
                    break;
                case 221:
                    textId = this.integer();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                vParent.TextId = textId;
            }
            switch (this.LA(1)) {
                case 100:
                case 171:
                case 199:
                case 221:
                case 224:
                case 230:
                case 231:
                case 234:
                    break;
                case 232: {
                        token = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.Match(token, "TIMESTAMP");
                        }
                        this.match(206);
                        Literal timestamp = this.binary();
                        if (base.inputState.guessing == 0) {
                            vParent.Timestamp = timestamp;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ScalarExpression signedIntegerOrVariableOrNull() {
            switch (this.LA(1)) {
                case 199:
                case 221:
                case 234:
                    return this.signedIntegerOrVariable();
                case 100:
                    return this.nullLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void modificationTextStatementWithLog(TextModificationStatement vParent) {
            IToken token = null;
            this.match(171);
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "LOG");
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                vParent.WithLog = true;
            }
        }

        public ValueExpression writeString() {
            switch (this.LA(1)) {
                case 100:
                    return this.nullLiteral();
                case 230:
                case 231:
                    return this.stringLiteral();
                case 224:
                    return this.binary();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public BinaryLiteral binary() {
            BinaryLiteral binaryLiteral = base.FragmentFactory.CreateFragment<BinaryLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(224);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(binaryLiteral, token);
                binaryLiteral.Value = token.getText();
                binaryLiteral.IsLargeObject = TSql80ParserBaseInternal.IsBinaryLiteralLob(binaryLiteral.Value);
            }
            return binaryLiteral;
        }

        public NullLiteral nullLiteral() {
            NullLiteral nullLiteral = base.FragmentFactory.CreateFragment<NullLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(100);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(nullLiteral, token);
                nullLiteral.Value = token.getText();
            }
            return nullLiteral;
        }

        public VariableReference variable() {
            VariableReference variableReference = base.FragmentFactory.CreateFragment<VariableReference>();
            IToken token = null;
            token = this.LT(1);
            this.match(234);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(variableReference, token);
                variableReference.Name = token.getText();
            }
            return variableReference;
        }

        public CursorId cursorId() {
            CursorId cursorId = base.FragmentFactory.CreateFragment<CursorId>();
            IToken token = null;
            if (this.LA(1) == 232 && (this.LA(2) == 232 || this.LA(2) == 233) && base.NextTokenMatches("GLOBAL")) {
                token = this.LT(1);
                this.match(232);
                Identifier identifier = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token, "GLOBAL");
                    cursorId.Name = base.IdentifierOrValueExpression(identifier);
                    cursorId.IsGlobal = true;
                }
                goto IL_00f6;
            }
            if (this.LA(1) >= 232 && this.LA(1) <= 234 && TSql80ParserInternal.tokenSet_29_.member(this.LA(2))) {
                IdentifierOrValueExpression name = this.identifierOrVariable();
                if (base.inputState.guessing == 0) {
                    cursorId.Name = name;
                    cursorId.IsGlobal = false;
                }
                goto IL_00f6;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00f6:
            return cursorId;
        }

        public FetchCursorStatement rowSelector() {
            FetchCursorStatement fetchCursorStatement = base.FragmentFactory.CreateFragment<FetchCursorStatement>();
            if (this.LA(1) >= 232 && this.LA(1) <= 234 && TSql80ParserInternal.tokenSet_30_.member(this.LA(2))) {
                CursorId cursor = this.cursorId();
                if (base.inputState.guessing == 0) {
                    fetchCursorStatement.Cursor = cursor;
                }
                goto IL_00f5;
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_31_.member(this.LA(2))) {
                FetchType fetchType = this.fetchType();
                this.match(71);
                CursorId cursor = this.cursorId();
                if (base.inputState.guessing == 0) {
                    fetchCursorStatement.Cursor = cursor;
                    fetchCursorStatement.FetchType = fetchType;
                }
                goto IL_00f5;
            }
            if (this.LA(1) == 71) {
                this.match(71);
                CursorId cursor = this.cursorId();
                if (base.inputState.guessing == 0) {
                    fetchCursorStatement.Cursor = cursor;
                }
                goto IL_00f5;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00f5:
            return fetchCursorStatement;
        }

        public FetchType fetchType() {
            FetchType fetchType = base.FragmentFactory.CreateFragment<FetchType>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                fetchType.Orientation = FetchOrientationHelper.Instance.ParseOption(token);
            }
            switch (this.LA(1)) {
                case 199:
                case 221: {
                        ScalarExpression rowOffset = this.signedInteger();
                        if (base.inputState.guessing == 0) {
                            if (fetchType.Orientation != FetchOrientation.Relative && fetchType.Orientation != FetchOrientation.Absolute) {
                                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                            }
                            fetchType.RowOffset = rowOffset;
                        }
                        break;
                    }
                case 234: {
                        ScalarExpression rowOffset = this.variable();
                        if (base.inputState.guessing == 0) {
                            if (fetchType.Orientation != FetchOrientation.Relative && fetchType.Orientation != FetchOrientation.Absolute) {
                                throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                            }
                            fetchType.RowOffset = rowOffset;
                        }
                        break;
                    }
                case 71:
                    if (base.inputState.guessing != 0) {
                        break;
                    }
                    if (fetchType.Orientation != FetchOrientation.Relative && fetchType.Orientation != FetchOrientation.Absolute) {
                        break;
                    }
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token);
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return fetchType;
        }

        public DropDatabaseStatement dropDatabaseStatement() {
            DropDatabaseStatement dropDatabaseStatement = base.FragmentFactory.CreateFragment<DropDatabaseStatement>();
            this.match(43);
            Identifier item = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropDatabaseStatement, dropDatabaseStatement.Databases, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.identifier();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropDatabaseStatement, dropDatabaseStatement.Databases, item);
                }
            }
            return dropDatabaseStatement;
        }

        public DropIndexStatement dropIndexStatement() {
            DropIndexStatement dropIndexStatement = base.FragmentFactory.CreateFragment<DropIndexStatement>();
            this.match(84);
            DropIndexClauseBase item = this.indexDropObject();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropIndexStatement, dropIndexStatement.DropIndexClauses, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.indexDropObject();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropIndexStatement, dropIndexStatement.DropIndexClauses, item);
                }
            }
            return dropIndexStatement;
        }

        public DropStatisticsStatement dropStatisticsStatement() {
            DropStatisticsStatement dropStatisticsStatement = base.FragmentFactory.CreateFragment<DropStatisticsStatement>();
            this.match(146);
            ChildObjectName item = this.statisticsDropObject();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropStatisticsStatement, dropStatisticsStatement.Objects, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.statisticsDropObject();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(dropStatisticsStatement, dropStatisticsStatement.Objects, item);
                }
            }
            return dropStatisticsStatement;
        }

        public DropTableStatement dropTableStatement() {
            DropTableStatement dropTableStatement = base.FragmentFactory.CreateFragment<DropTableStatement>();
            this.match(148);
            this.dropObjectList(dropTableStatement, false);
            return dropTableStatement;
        }

        public DropProcedureStatement dropProcedureStatement() {
            DropProcedureStatement dropProcedureStatement = base.FragmentFactory.CreateFragment<DropProcedureStatement>();
            switch (this.LA(1)) {
                case 121:
                    this.match(121);
                    break;
                case 120:
                    this.match(120);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            this.dropObjectList(dropProcedureStatement, true);
            return dropProcedureStatement;
        }

        public DropFunctionStatement dropFunctionStatement() {
            DropFunctionStatement dropFunctionStatement = base.FragmentFactory.CreateFragment<DropFunctionStatement>();
            this.match(73);
            this.dropObjectList(dropFunctionStatement, true);
            return dropFunctionStatement;
        }

        public DropViewStatement dropViewStatement() {
            DropViewStatement dropViewStatement = base.FragmentFactory.CreateFragment<DropViewStatement>();
            this.match(166);
            this.dropObjectList(dropViewStatement, true);
            return dropViewStatement;
        }

        public DropDefaultStatement dropDefaultStatement() {
            DropDefaultStatement dropDefaultStatement = base.FragmentFactory.CreateFragment<DropDefaultStatement>();
            this.match(47);
            this.dropObjectList(dropDefaultStatement, true);
            return dropDefaultStatement;
        }

        public DropRuleStatement dropRuleStatement() {
            DropRuleStatement dropRuleStatement = base.FragmentFactory.CreateFragment<DropRuleStatement>();
            this.match(137);
            this.dropObjectList(dropRuleStatement, true);
            return dropRuleStatement;
        }

        public DropTriggerStatement dropTriggerStatement() {
            DropTriggerStatement dropTriggerStatement = base.FragmentFactory.CreateFragment<DropTriggerStatement>();
            this.match(155);
            this.dropObjectList(dropTriggerStatement, true);
            return dropTriggerStatement;
        }

        public BackwardsCompatibleDropIndexClause indexDropObject() {
            BackwardsCompatibleDropIndexClause backwardsCompatibleDropIndexClause = base.FragmentFactory.CreateFragment<BackwardsCompatibleDropIndexClause>();
            ChildObjectName childObjectName = this.childObjectNameWithThreePrefixes();
            if (base.inputState.guessing == 0) {
                if (childObjectName.BaseIdentifier == null) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46027", childObjectName, TSqlParserResource.SQL46027Message);
                }
                backwardsCompatibleDropIndexClause.Index = childObjectName;
            }
            return backwardsCompatibleDropIndexClause;
        }

        public ChildObjectName statisticsDropObject() {
            ChildObjectName childObjectName = this.childObjectNameWithThreePrefixes();
            if (base.inputState.guessing == 0 && childObjectName.BaseIdentifier == null) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46038", childObjectName, TSqlParserResource.SQL46038Message);
            }
            return childObjectName;
        }

        public List<Identifier> identifierList(int vMaxNumber) {
            List<Identifier> list = new List<Identifier>();
            Identifier identifier = null;
            switch (this.LA(1)) {
                case 232:
                case 233:
                    identifier = this.identifier();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.AddIdentifierToListWithCheck(list, identifier, vMaxNumber);
                    }
                    while (true) {
                        if (this.LA(1) != 200) {
                            break;
                        }
                        if (this.LA(2) != 200 && this.LA(2) != 232 && this.LA(2) != 233) {
                            break;
                        }
                        this.identifierListElement(list, vMaxNumber, false);
                    }
                    break;
                case 200:
                    this.identifierListElement(list, vMaxNumber, true);
                    while (true) {
                        if (this.LA(1) != 200) {
                            break;
                        }
                        if (this.LA(2) != 200 && this.LA(2) != 232 && this.LA(2) != 233) {
                            break;
                        }
                        this.identifierListElement(list, vMaxNumber, false);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return list;
        }

        public void dropObjectList(DropObjectsStatement vParent, bool onlyTwoPartNames) {
            SchemaObjectName item = this.dropObject(onlyTwoPartNames);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Objects, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.dropObject(onlyTwoPartNames);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Objects, item);
                }
            }
        }

        public SchemaObjectName dropObject(bool onlyTwoPartNames) {
            SchemaObjectName schemaObjectName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0 && onlyTwoPartNames) {
                TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(schemaObjectName, "DROP");
            }
            return schemaObjectName;
        }

        public Identifier nonQuotedIdentifier() {
            Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
                identifier.SetUnquotedIdentifier(token.getText());
            }
            return identifier;
        }

        public BeginTransactionStatement beginTransactionStatement() {
            BeginTransactionStatement beginTransactionStatement = base.FragmentFactory.CreateFragment<BeginTransactionStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            token = this.LT(1);
            this.match(13);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(beginTransactionStatement, token);
            }
            switch (this.LA(1)) {
                case 52:
                    this.match(52);
                    if (base.inputState.guessing == 0) {
                        beginTransactionStatement.Distributed = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 153:
                case 154:
                    break;
            }
            switch (this.LA(1)) {
                case 153:
                    token2 = this.LT(1);
                    this.match(153);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(beginTransactionStatement, token2);
                    }
                    break;
                case 154:
                    token3 = this.LT(1);
                    this.match(154);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(beginTransactionStatement, token3);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_03be;
                }
            } else {
                switch (num) {
                    case 199:
                    case 221:
                    case 232:
                    case 233:
                    case 234:
                        this.transactionName(beginTransactionStatement);
                        goto IL_03be;
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_03be;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_03be:
            int num2 = this.LA(1);
            if (num2 <= 86) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0946;
                }
                goto IL_0933;
            }
            switch (num2) {
                case 171:
                    break;
                default:
                    goto IL_0933;
                case 92:
                case 95:
                case 106:
                case 119:
                case 123:
                case 125:
                case 126:
                case 129:
                case 131:
                case 132:
                case 134:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 204:
                case 219:
                case 220:
                    goto IL_0946;
            }
            this.match(171);
            token4 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token4, "MARK");
                TSql80ParserBaseInternal.UpdateTokenInfo(beginTransactionStatement, token4);
                beginTransactionStatement.MarkDefined = true;
            }
            int num3 = this.LA(1);
            if (num3 <= 92) {
                switch (num3) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0946;
                }
            } else {
                switch (num3) {
                    case 230:
                    case 231:
                    case 234: {
                            ValueExpression markDescription = this.stringOrVariable();
                            if (base.inputState.guessing == 0) {
                                beginTransactionStatement.MarkDescription = markDescription;
                            }
                            goto IL_0946;
                        }
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0946;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0946:
            return beginTransactionStatement;
            IL_0933:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void transactionName(TransactionStatement vParent) {
            switch (this.LA(1)) {
                case 232:
                case 233:
                case 234: {
                        IdentifierOrValueExpression name = this.identifierOrVariable();
                        if (base.inputState.guessing == 0) {
                            vParent.Name = name;
                        }
                        break;
                    }
                case 199:
                case 221: {
                        Identifier identifier = this.weirdTransactionName();
                        if (base.inputState.guessing == 0) {
                            vParent.Name = base.IdentifierOrValueExpression(identifier);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public Identifier weirdTransactionName() {
            Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            StringBuilder stringBuilder = new StringBuilder();
            switch (this.LA(1)) {
                case 199:
                    token = this.LT(1);
                    this.match(199);
                    if (base.inputState.guessing == 0) {
                        stringBuilder.Append(token.getText());
                        TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 221:
                    break;
            }
            token2 = this.LT(1);
            this.match(221);
            token3 = this.LT(1);
            this.match(202);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identifier, token2);
                stringBuilder.Append(token2.getText());
                stringBuilder.Append(token3.getText());
            }
            this.tranIdentifier(stringBuilder, identifier);
            token4 = this.LT(1);
            this.match(200);
            if (base.inputState.guessing == 0) {
                stringBuilder.Append(token4.getText());
            }
            this.tranIdentifier(stringBuilder, identifier);
            if (base.inputState.guessing == 0) {
                identifier.Value = stringBuilder.ToString();
            }
            return identifier;
        }

        public void tranIdentifier(StringBuilder vStringBuilder, TSqlFragment vParent) {
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        vStringBuilder.Append(token.getText());
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                case 233:
                    token2 = this.LT(1);
                    this.match(233);
                    if (base.inputState.guessing == 0) {
                        vStringBuilder.Append(token2.getText());
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public DeclareVariableElement declareVariableElement() {
            DeclareVariableElement declareVariableElement = base.FragmentFactory.CreateFragment<DeclareVariableElement>();
            Identifier variableName = this.identifierVariable();
            switch (this.LA(1)) {
                case 9:
                    this.match(9);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 42:
                case 53:
                case 96:
                case 232:
                case 233:
                    break;
            }
            DataTypeReference dataType;
            switch (this.LA(1)) {
                case 53:
                case 96:
                case 232:
                case 233:
                    dataType = this.scalarDataType();
                    break;
                case 42:
                    dataType = this.cursorDataType();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                declareVariableElement.VariableName = variableName;
                declareVariableElement.DataType = dataType;
            }
            return declareVariableElement;
        }

        public SqlDataTypeReference cursorDataType() {
            SqlDataTypeReference sqlDataTypeReference = base.FragmentFactory.CreateFragment<SqlDataTypeReference>();
            IToken token = null;
            token = this.LT(1);
            this.match(42);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(sqlDataTypeReference, token);
                sqlDataTypeReference.SqlDataTypeOption = SqlDataTypeOption.Cursor;
            }
            return sqlDataTypeReference;
        }

        public DeclareVariableStatement declareVariableStatement() {
            DeclareVariableStatement declareVariableStatement = base.FragmentFactory.CreateFragment<DeclareVariableStatement>();
            DeclareVariableElement item = this.declareVariableElement();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(declareVariableStatement, declareVariableStatement.Declarations, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.declareVariableElement();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(declareVariableStatement, declareVariableStatement.Declarations, item);
                }
            }
            return declareVariableStatement;
        }

        public DeclareCursorStatement declareCursorStatement() {
            DeclareCursorStatement declareCursorStatement = base.FragmentFactory.CreateFragment<DeclareCursorStatement>();
            List<CursorOption> vOptions = new List<CursorOption>();
            Identifier name = this.identifier();
            this.cursorOpts(true, vOptions);
            CursorDefinition cursorDefinition = this.cursorDefinitionOptions(vOptions);
            if (base.inputState.guessing == 0) {
                declareCursorStatement.Name = name;
                declareCursorStatement.CursorDefinition = cursorDefinition;
            }
            return declareCursorStatement;
        }

        public PredicateSetStatement predicateSetStatement() {
            PredicateSetStatement predicateSetStatement = base.FragmentFactory.CreateFragment<PredicateSetStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                predicateSetStatement.Options = PredicateSetOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                token2 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    predicateSetStatement.Options |= PredicateSetOptionsHelper.Instance.ParseOption(token2, SqlVersionFlags.TSql80);
                }
            }
            this.setOnOff(predicateSetStatement);
            if (base.inputState.guessing == 0 && (predicateSetStatement.Options & SetOptions.QuotedIdentifier) == SetOptions.QuotedIdentifier) {
                base._tokenSource.QuotedIdentifier = predicateSetStatement.IsOn;
            }
            return predicateSetStatement;
        }

        public SetVariableStatement setVariableStatement() {
            SetVariableStatement setVariableStatement = base.FragmentFactory.CreateFragment<SetVariableStatement>();
            VariableReference variable = this.variable();
            if (base.inputState.guessing == 0) {
                setVariableStatement.Variable = variable;
            }
            this.match(206);
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235: {
                        ScalarExpression expression = this.expression();
                        if (base.inputState.guessing == 0) {
                            setVariableStatement.Expression = expression;
                        }
                        break;
                    }
                case 42: {
                        CursorDefinition cursorDefinition = this.cursorDefinition();
                        if (base.inputState.guessing == 0) {
                            setVariableStatement.CursorDefinition = cursorDefinition;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return setVariableStatement;
        }

        public SetStatisticsStatement setStatisticsStatement() {
            SetStatisticsStatement setStatisticsStatement = base.FragmentFactory.CreateFragment<SetStatisticsStatement>();
            IToken token = null;
            IToken token2 = null;
            this.match(146);
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                setStatisticsStatement.Options = SetStatisticsOptionsHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                token2 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    setStatisticsStatement.Options |= SetStatisticsOptionsHelper.Instance.ParseOption(token2, SqlVersionFlags.TSql80);
                }
            }
            this.setOnOff(setStatisticsStatement);
            return setStatisticsStatement;
        }

        public SetRowCountStatement setRowcountStatement() {
            SetRowCountStatement setRowCountStatement = base.FragmentFactory.CreateFragment<SetRowCountStatement>();
            this.match(135);
            ValueExpression numberRows = this.integerOrVariable();
            if (base.inputState.guessing == 0) {
                setRowCountStatement.NumberRows = numberRows;
            }
            return setRowCountStatement;
        }

        public SetOffsetsStatement setOffsetsStatement() {
            SetOffsetsStatement setOffsetsStatement = base.FragmentFactory.CreateFragment<SetOffsetsStatement>();
            this.match(104);
            SetOffsets options = this.offsetItem();
            if (base.inputState.guessing == 0) {
                setOffsetsStatement.Options = options;
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                options = this.offsetItem();
                if (base.inputState.guessing == 0) {
                    setOffsetsStatement.Options |= options;
                }
            }
            this.setOnOff(setOffsetsStatement);
            return setOffsetsStatement;
        }

        public SetCommandStatement setCommandStatement() {
            SetCommandStatement setCommandStatement = base.FragmentFactory.CreateFragment<SetCommandStatement>();
            SetCommand item = this.setCommand();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(setCommandStatement, setCommandStatement.Commands, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.setCommand();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(setCommandStatement, setCommandStatement.Commands, item);
                }
            }
            return setCommandStatement;
        }

        public SetTransactionIsolationLevelStatement setTransactionIsolationLevelStatement() {
            SetTransactionIsolationLevelStatement setTransactionIsolationLevelStatement = base.FragmentFactory.CreateFragment<SetTransactionIsolationLevelStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            IToken token6 = null;
            switch (this.LA(1)) {
                case 154:
                    this.match(154);
                    break;
                case 153:
                    this.match(153);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token = this.LT(1);
            this.match(232);
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "ISOLATION");
                TSql80ParserBaseInternal.Match(token2, "LEVEL");
            }
            if (this.LA(1) == 124) {
                this.match(124);
                token3 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    if (TSql80ParserBaseInternal.TryMatch(token3, "COMMITTED")) {
                        setTransactionIsolationLevelStatement.Level = IsolationLevel.ReadCommitted;
                    } else {
                        TSql80ParserBaseInternal.Match(token3, "UNCOMMITTED");
                        setTransactionIsolationLevelStatement.Level = IsolationLevel.ReadUncommitted;
                    }
                    TSql80ParserBaseInternal.UpdateTokenInfo(setTransactionIsolationLevelStatement, token3);
                }
                goto IL_01f8;
            }
            if (this.LA(1) == 232 && this.LA(2) == 124) {
                token4 = this.LT(1);
                this.match(232);
                token5 = this.LT(1);
                this.match(124);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token4, "REPEATABLE");
                    setTransactionIsolationLevelStatement.Level = IsolationLevel.RepeatableRead;
                    TSql80ParserBaseInternal.UpdateTokenInfo(setTransactionIsolationLevelStatement, token5);
                }
                goto IL_01f8;
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_10_.member(this.LA(2))) {
                token6 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token6, "SERIALIZABLE");
                    setTransactionIsolationLevelStatement.Level = IsolationLevel.Serializable;
                    TSql80ParserBaseInternal.UpdateTokenInfo(setTransactionIsolationLevelStatement, token6);
                }
                goto IL_01f8;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_01f8:
            return setTransactionIsolationLevelStatement;
        }

        public SetTextSizeStatement setTextSizeStatement() {
            SetTextSizeStatement setTextSizeStatement = base.FragmentFactory.CreateFragment<SetTextSizeStatement>();
            this.match(149);
            ScalarExpression textSize = this.signedInteger();
            if (base.inputState.guessing == 0) {
                setTextSizeStatement.TextSize = textSize;
            }
            return setTextSizeStatement;
        }

        public SetIdentityInsertStatement setIdentityInsertStatement() {
            SetIdentityInsertStatement setIdentityInsertStatement = base.FragmentFactory.CreateFragment<SetIdentityInsertStatement>();
            this.match(80);
            SchemaObjectName table = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                setIdentityInsertStatement.Table = table;
            }
            this.setOnOff(setIdentityInsertStatement);
            return setIdentityInsertStatement;
        }

        public SetErrorLevelStatement setErrorLevelStatement() {
            SetErrorLevelStatement setErrorLevelStatement = base.FragmentFactory.CreateFragment<SetErrorLevelStatement>();
            this.match(57);
            ScalarExpression level = this.signedInteger();
            if (base.inputState.guessing == 0) {
                setErrorLevelStatement.Level = level;
            }
            return setErrorLevelStatement;
        }

        public CursorDefinition cursorDefinition() {
            List<CursorOption> vOptions = new List<CursorOption>();
            return this.cursorDefinitionOptions(vOptions);
        }

        public void setOnOff(SetOnOffStatement vParent) {
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 105:
                    token = this.LT(1);
                    this.match(105);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                        vParent.IsOn = true;
                    }
                    break;
                case 103:
                    token2 = this.LT(1);
                    this.match(103);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                        vParent.IsOn = false;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public SetOffsets offsetItem() {
            SetOffsets result = SetOffsets.None;
            IToken token = null;
            switch (this.LA(1)) {
                case 140:
                    this.match(140);
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Select;
                    }
                    break;
                case 71:
                    this.match(71);
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.From;
                    }
                    break;
                case 113:
                    this.match(113);
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Order;
                    }
                    break;
                case 29:
                    this.match(29);
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Compute;
                    }
                    break;
                case 148:
                    this.match(148);
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Table;
                    }
                    break;
                case 120:
                case 121:
                    switch (this.LA(1)) {
                        case 121:
                            this.match(121);
                            break;
                        case 120:
                            this.match(120);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Procedure;
                    }
                    break;
                case 60:
                case 61:
                    switch (this.LA(1)) {
                        case 61:
                            this.match(61);
                            break;
                        case 60:
                            this.match(60);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    if (base.inputState.guessing == 0) {
                        result = SetOffsets.Execute;
                    }
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        if (TSql80ParserBaseInternal.TryMatch(token, "STATEMENT")) {
                            result = SetOffsets.Statement;
                        } else {
                            TSql80ParserBaseInternal.Match(token, "PARAM");
                            result = SetOffsets.Param;
                        }
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public SetCommand setCommand() {
            SetCommand result = null;
            IToken token = null;
            if (this.LA(1) == 232 && (this.LA(2) == 103 || this.LA(2) == 230 || this.LA(2) == 231) && base.NextTokenMatches("FIPS_FLAGGER")) {
                this.LT(1);
                this.match(232);
                result = this.fipsFlaggerLevel();
                goto IL_00e8;
            }
            if (this.LA(1) == 232 && TSql80ParserInternal.tokenSet_24_.member(this.LA(2))) {
                token = this.LT(1);
                this.match(232);
                ScalarExpression parameter = this.possibleNegativeConstantOrIdentifier();
                if (base.inputState.guessing == 0) {
                    GeneralSetCommand generalSetCommand = base.FragmentFactory.CreateFragment<GeneralSetCommand>();
                    generalSetCommand.CommandType = GeneralSetCommandTypeHelper.Instance.ParseOption(token);
                    generalSetCommand.Parameter = parameter;
                    result = generalSetCommand;
                }
                goto IL_00e8;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00e8:
            return result;
        }

        public SetFipsFlaggerCommand fipsFlaggerLevel() {
            SetFipsFlaggerCommand setFipsFlaggerCommand = base.FragmentFactory.CreateFragment<SetFipsFlaggerCommand>();
            IToken token = null;
            switch (this.LA(1)) {
                case 103:
                    token = this.LT(1);
                    this.match(103);
                    if (base.inputState.guessing == 0) {
                        setFipsFlaggerCommand.ComplianceLevel = FipsComplianceLevel.Off;
                        TSql80ParserBaseInternal.UpdateTokenInfo(setFipsFlaggerCommand, token);
                    }
                    break;
                case 230:
                case 231: {
                        StringLiteral fragment = this.stringLiteral();
                        if (base.inputState.guessing == 0) {
                            setFipsFlaggerCommand.ComplianceLevel = FipsComplianceLevelHelper.Instance.ParseOption(TSql80ParserBaseInternal.GetFirstToken(fragment));
                            setFipsFlaggerCommand.UpdateTokenInfo(fragment);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return setFipsFlaggerCommand;
        }

        public DeclareTableVariableBody declareTableBodyMain(IndexAffectingStatement statementType) {
            DeclareTableVariableBody declareTableVariableBody = base.FragmentFactory.CreateFragment<DeclareTableVariableBody>();
            IToken token = null;
            this.match(191);
            TableDefinition definition = this.tableDefinition(statementType, null);
            if (base.inputState.guessing == 0) {
                declareTableVariableBody.Definition = definition;
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(declareTableVariableBody, token);
            }
            return declareTableVariableBody;
        }

        public TableDefinition tableDefinition(IndexAffectingStatement statementType, AlterTableAddTableElementStatement vStatement) {
            TableDefinition tableDefinition = base.FragmentFactory.CreateFragment<TableDefinition>();
            if (base.PhaseOne && vStatement != null) {
                vStatement.Definition = tableDefinition;
            }
            this.tableElement(statementType, tableDefinition, vStatement);
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                this.tableElement(statementType, tableDefinition, vStatement);
            }
            return tableDefinition;
        }

        public void tableElement(IndexAffectingStatement statementType, TableDefinition vParent, AlterTableAddTableElementStatement vStatement) {
            switch (this.LA(1)) {
                case 232:
                case 233: {
                        ColumnDefinition item2 = this.columnDefinition(statementType, vStatement);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.ColumnDefinitions, item2);
                        }
                        break;
                    }
                case 21:
                case 30:
                case 47:
                case 68:
                case 118:
                case 159: {
                        ConstraintDefinition item = this.tableConstraint(statementType, vStatement);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.TableConstraints, item);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void cursorOpts(bool oldSyntax, IList<CursorOption> vOptions) {
            while (true) {
                if (this.LA(1) != 232) {
                    break;
                }
                CursorOption cursorOption = this.cursorOption();
                if (base.inputState.guessing == 0) {
                    if (oldSyntax) {
                        if (cursorOption.OptionKind != CursorOptionKind.Insensitive && cursorOption.OptionKind != CursorOptionKind.Scroll) {
                            TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(cursorOption);
                        }
                    } else if (cursorOption.OptionKind == CursorOptionKind.Insensitive) {
                        TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(cursorOption);
                    }
                    vOptions.Add(cursorOption);
                }
            }
        }

        public CursorDefinition cursorDefinitionOptions(IList<CursorOption> vOptions) {
            CursorDefinition cursorDefinition = base.FragmentFactory.CreateFragment<CursorDefinition>();
            this.match(42);
            this.cursorOpts(false, vOptions);
            this.match(67);
            SelectStatement select = this.selectStatement();
            if (base.inputState.guessing == 0) {
                cursorDefinition.Select = select;
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(cursorDefinition, cursorDefinition.Options, vOptions);
            }
            return cursorDefinition;
        }

        public SelectStatement selectStatement() {
            SelectStatement selectStatement = null;
            return this.select();
        }

        public CursorOption cursorOption() {
            CursorOption cursorOption = base.FragmentFactory.CreateFragment<CursorOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                cursorOption.OptionKind = CursorOptionsHelper.Instance.ParseOption(token);
            }
            return cursorOption;
        }

        public void indexLegacyOptionList(CreateIndexStatement vParent) {
            IndexOption indexOption = this.indexLegacyOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.VerifyAllowedIndexOption(IndexAffectingStatement.CreateIndex, indexOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.IndexOptions, indexOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                indexOption = this.indexLegacyOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.VerifyAllowedIndexOption(IndexAffectingStatement.CreateIndex, indexOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.IndexOptions, indexOption);
                }
            }
        }

        public FileGroupOrPartitionScheme filegroupOrPartitionScheme() {
            FileGroupOrPartitionScheme fileGroupOrPartitionScheme = base.FragmentFactory.CreateFragment<FileGroupOrPartitionScheme>();
            IdentifierOrValueExpression name = this.stringOrIdentifier();
            if (base.inputState.guessing == 0) {
                fileGroupOrPartitionScheme.Name = name;
            }
            return fileGroupOrPartitionScheme;
        }

        public IndexOption indexLegacyOption() {
            IndexOption result = null;
            IToken token = null;
            switch (this.LA(1)) {
                case 66:
                    result = this.fillFactorOption();
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        IndexStateOption indexStateOption = base.FragmentFactory.CreateFragment<IndexStateOption>();
                        result = indexStateOption;
                        indexStateOption.OptionKind = TSql80ParserBaseInternal.ParseIndexLegacyWithOption(token);
                        TSql80ParserBaseInternal.UpdateTokenInfo(indexStateOption, token);
                        indexStateOption.OptionState = OptionState.On;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public IndexExpressionOption fillFactorOption() {
            IndexExpressionOption indexExpressionOption = base.FragmentFactory.CreateFragment<IndexExpressionOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(66);
            this.match(206);
            Literal literal = this.integer();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckFillFactorRange(literal);
                indexExpressionOption.OptionKind = IndexOptionKind.FillFactor;
                indexExpressionOption.Expression = literal;
                TSql80ParserBaseInternal.UpdateTokenInfo(indexExpressionOption, token);
            }
            return indexExpressionOption;
        }

        public QueryExpression subqueryExpression() {
            QueryExpression queryExpression = null;
            BinaryQueryExpression binaryQueryExpression = null;
            queryExpression = this.subqueryExpressionUnit();
            while (true) {
                if (this.LA(1) != 59 && this.LA(1) != 87 && this.LA(1) != 158) {
                    break;
                }
                if (base.inputState.guessing == 0) {
                    binaryQueryExpression = base.FragmentFactory.CreateFragment<BinaryQueryExpression>();
                    binaryQueryExpression.FirstQueryExpression = queryExpression;
                }
                switch (this.LA(1)) {
                    case 158:
                        this.match(158);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Union;
                        }
                        break;
                    case 59:
                        this.match(59);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Except;
                        }
                        break;
                    case 87:
                        this.match(87);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Intersect;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                switch (this.LA(1)) {
                    case 5:
                        this.match(5);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.All = true;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 140:
                    case 191:
                        break;
                }
                queryExpression = this.subqueryExpressionUnit();
                if (base.inputState.guessing == 0) {
                    binaryQueryExpression.SecondQueryExpression = queryExpression;
                    queryExpression = binaryQueryExpression;
                }
            }
            return queryExpression;
        }

        public QueryExpression queryExpression(SelectStatement vSelectStatement) {
            QueryExpression queryExpression = null;
            BinaryQueryExpression binaryQueryExpression = null;
            queryExpression = this.queryExpressionUnit(vSelectStatement);
            while (true) {
                if (this.LA(1) != 59 && this.LA(1) != 87 && this.LA(1) != 158) {
                    break;
                }
                if (base.inputState.guessing == 0) {
                    binaryQueryExpression = base.FragmentFactory.CreateFragment<BinaryQueryExpression>();
                    binaryQueryExpression.FirstQueryExpression = queryExpression;
                }
                switch (this.LA(1)) {
                    case 158:
                        this.match(158);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Union;
                        }
                        break;
                    case 59:
                        this.match(59);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Except;
                        }
                        break;
                    case 87:
                        this.match(87);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.BinaryQueryExpressionType = BinaryQueryExpressionType.Intersect;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                switch (this.LA(1)) {
                    case 5:
                        this.match(5);
                        if (base.inputState.guessing == 0) {
                            binaryQueryExpression.All = true;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 140:
                    case 191:
                        break;
                }
                queryExpression = this.queryExpressionUnit(null);
                if (base.inputState.guessing == 0) {
                    binaryQueryExpression.SecondQueryExpression = queryExpression;
                    queryExpression = binaryQueryExpression;
                }
            }
            return queryExpression;
        }

        public OrderByClause orderByClause() {
            OrderByClause orderByClause = base.FragmentFactory.CreateFragment<OrderByClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(113);
            this.match(18);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(orderByClause, token);
            }
            ExpressionWithSortOrder item = this.expressionWithSortOrder();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(orderByClause, orderByClause.OrderByElements, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.expressionWithSortOrder();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(orderByClause, orderByClause.OrderByElements, item);
                }
            }
            return orderByClause;
        }

        public ComputeClause computeClause() {
            ComputeClause computeClause = base.FragmentFactory.CreateFragment<ComputeClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(29);
            ComputeFunction item = this.computeFunction();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(computeClause, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(computeClause, computeClause.ComputeFunctions, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.computeFunction();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(computeClause, computeClause.ComputeFunctions, item);
                }
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 18:
                        this.match(18);
                        this.expressionList(computeClause, computeClause.ByExpressions);
                        goto IL_0310;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_0310;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0310;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0310:
            return computeClause;
        }

        public ForClause forClause() {
            ForClause forClause = null;
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(67);
            switch (this.LA(1)) {
                case 16:
                    forClause = this.browseForClause();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(forClause, token);
                    }
                    break;
                case 124:
                    this.match(124);
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "ONLY");
                        forClause = base.FragmentFactory.CreateFragment<ReadOnlyForClause>();
                        TSql80ParserBaseInternal.UpdateTokenInfo(forClause, token2);
                    }
                    break;
                case 232:
                    forClause = this.xmlForClause();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(forClause, token);
                    }
                    break;
                case 160:
                    forClause = this.updateForClause();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(forClause, token);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return forClause;
        }

        public void optimizerHints(TSqlFragment vParent, IList<OptimizerHint> hintsCollection) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(111);
            this.match(191);
            OptimizerHint item = this.hint();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hintsCollection, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.hint();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hintsCollection, item);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
        }

        public QueryDerivedTable derivedTable() {
            QueryDerivedTable queryDerivedTable = base.FragmentFactory.CreateFragment<QueryDerivedTable>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            QueryExpression queryExpression = this.subqueryExpression();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                queryDerivedTable.QueryExpression = queryExpression;
                TSql80ParserBaseInternal.UpdateTokenInfo(queryDerivedTable, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(queryDerivedTable, token2);
            }
            this.simpleTableReferenceAlias(queryDerivedTable);
            if (this.LA(1) == 191 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                this.columnNameList(queryDerivedTable, queryDerivedTable.Columns);
                goto IL_00d8;
            }
            if (TSql80ParserInternal.tokenSet_32_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                goto IL_00d8;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00d8:
            return queryDerivedTable;
        }

        public void simpleTableReferenceAlias(TableReferenceWithAlias vParent) {
            switch (this.LA(1)) {
                case 9:
                    this.match(9);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 232:
                case 233:
                    break;
            }
            Identifier alias = this.identifier();
            if (base.inputState.guessing == 0) {
                vParent.Alias = alias;
            }
        }

        public ScalarSubquery subquery(ExpressionFlags expressionFlags) {
            ScalarSubquery scalarSubquery = base.FragmentFactory.CreateFragment<ScalarSubquery>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            QueryExpression queryExpression = this.subqueryExpression();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                if (ExpressionFlags.ScalarSubqueriesDisallowed == (expressionFlags & ExpressionFlags.ScalarSubqueriesDisallowed)) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46098", queryExpression, TSqlParserResource.SQL46098Message);
                }
                scalarSubquery.QueryExpression = queryExpression;
                TSql80ParserBaseInternal.UpdateTokenInfo(scalarSubquery, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(scalarSubquery, token2);
            }
            return scalarSubquery;
        }

        public QueryExpression subqueryExpressionUnit() {
            QueryExpression queryExpression = null;
            switch (this.LA(1)) {
                case 140:
                    return this.subquerySpecification();
                case 191:
                    return this.subqueryParenthesis();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public QuerySpecification subquerySpecification() {
            QuerySpecification querySpecification = base.FragmentFactory.CreateFragment<QuerySpecification>();
            IToken token = null;
            token = this.LT(1);
            this.match(140);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(querySpecification, token);
            }
            switch (this.LA(1)) {
                case 5:
                case 51: {
                        UniqueRowFilter uniqueRowFilter = this.uniqueRowFilter();
                        if (base.inputState.guessing == 0) {
                            querySpecification.UniqueRowFilter = uniqueRowFilter;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 152:
                case 163:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            switch (this.LA(1)) {
                case 152: {
                        TopRowFilter topRowFilter = this.topRowFilter();
                        if (base.inputState.guessing == 0) {
                            querySpecification.TopRowFilter = topRowFilter;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            SelectElement item = this.selectColumnOrStarExpression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(querySpecification, querySpecification.SelectElements, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.selectColumnOrStarExpression();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(querySpecification, querySpecification.SelectElements, item);
                }
            }
            FromClause fromClause = this.fromClauseOpt();
            if (base.inputState.guessing == 0) {
                querySpecification.FromClause = fromClause;
            }
            switch (this.LA(1)) {
                case 169: {
                        WhereClause whereClause = this.whereClause();
                        if (base.inputState.guessing == 0) {
                            querySpecification.WhereClause = whereClause;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 1:
                case 35:
                case 59:
                case 67:
                case 75:
                case 76:
                case 77:
                case 87:
                case 113:
                case 158:
                case 171:
                case 192:
                case 219:
                    break;
            }
            switch (this.LA(1)) {
                case 76: {
                        GroupByClause groupByClause = this.groupByClause();
                        if (base.inputState.guessing == 0) {
                            querySpecification.GroupByClause = groupByClause;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 1:
                case 35:
                case 59:
                case 67:
                case 75:
                case 77:
                case 87:
                case 113:
                case 158:
                case 171:
                case 192:
                case 219:
                    break;
            }
            switch (this.LA(1)) {
                case 77: {
                        HavingClause havingClause = this.havingClause();
                        if (base.inputState.guessing == 0) {
                            querySpecification.HavingClause = havingClause;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 1:
                case 35:
                case 59:
                case 67:
                case 75:
                case 87:
                case 113:
                case 158:
                case 171:
                case 192:
                case 219:
                    break;
            }
            switch (this.LA(1)) {
                case 113: {
                        OrderByClause orderByClause = this.orderByClause();
                        if (base.inputState.guessing == 0) {
                            querySpecification.OrderByClause = orderByClause;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 1:
                case 35:
                case 59:
                case 67:
                case 75:
                case 87:
                case 158:
                case 171:
                case 192:
                case 219:
                    break;
            }
            if (this.LA(1) == 67 && this.LA(1) == 67 && this.LA(2) == 16) {
                this.match(67);
                BrowseForClause forClause = this.browseForClause();
                if (base.inputState.guessing == 0) {
                    querySpecification.ForClause = forClause;
                }
            } else if (!TSql80ParserInternal.tokenSet_34_.member(this.LA(1))) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                if (querySpecification.OrderByClause != null && querySpecification.TopRowFilter == null) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46047", querySpecification, TSqlParserResource.SQL46047Message);
                }
                if (querySpecification.TopRowFilter != null && querySpecification.TopRowFilter.WithTies && querySpecification.OrderByClause == null) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46048", querySpecification, TSqlParserResource.SQL46048Message);
                }
            }
            return querySpecification;
        }

        public QueryParenthesisExpression subqueryParenthesis() {
            QueryParenthesisExpression queryParenthesisExpression = base.FragmentFactory.CreateFragment<QueryParenthesisExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(queryParenthesisExpression, token);
            }
            QueryExpression queryExpression = this.subqueryExpression();
            if (base.inputState.guessing == 0) {
                queryParenthesisExpression.QueryExpression = queryExpression;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(queryParenthesisExpression, token2);
            }
            return queryParenthesisExpression;
        }

        public QueryExpression queryExpressionUnit(SelectStatement vSelectStatement) {
            QueryExpression queryExpression = null;
            switch (this.LA(1)) {
                case 140:
                    return this.querySpecification(vSelectStatement);
                case 191:
                    return this.queryParenthesis(vSelectStatement);
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public QuerySpecification querySpecification(SelectStatement vSelectStatement) {
            QuerySpecification querySpecification = base.FragmentFactory.CreateFragment<QuerySpecification>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(140);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(querySpecification, token);
            }
            switch (this.LA(1)) {
                case 5:
                case 51: {
                        UniqueRowFilter uniqueRowFilter = this.uniqueRowFilter();
                        if (base.inputState.guessing == 0) {
                            querySpecification.UniqueRowFilter = uniqueRowFilter;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 152:
                case 163:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            switch (this.LA(1)) {
                case 152: {
                        TopRowFilter topRowFilter = this.topRowFilter();
                        if (base.inputState.guessing == 0) {
                            querySpecification.TopRowFilter = topRowFilter;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            this.selectExpression(querySpecification);
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                this.selectExpression(querySpecification);
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 88: {
                            token2 = this.LT(1);
                            this.match(88);
                            SchemaObjectName into = this.schemaObjectThreePartName();
                            if (base.inputState.guessing == 0) {
                                if (vSelectStatement == null) {
                                    TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token2);
                                }
                                vSelectStatement.Into = into;
                            }
                            goto IL_0739;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 71:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 82:
                    case 86:
                    case 87:
                    case 92:
                        goto IL_0739;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 111:
                    case 113:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 169:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0739;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0a46:
            int num2 = this.LA(1);
            if (num2 <= 95) {
                switch (num2) {
                    case 76: {
                            GroupByClause groupByClause = this.groupByClause();
                            if (base.inputState.guessing == 0) {
                                querySpecification.GroupByClause = groupByClause;
                            }
                            goto IL_0d30;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 77:
                    case 82:
                    case 86:
                    case 87:
                    case 92:
                    case 95:
                        goto IL_0d30;
                }
            } else {
                switch (num2) {
                    case 106:
                    case 111:
                    case 113:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0d30;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0d30:
            int num3 = this.LA(1);
            if (num3 <= 92) {
                switch (num3) {
                    case 77: {
                            HavingClause havingClause = this.havingClause();
                            if (base.inputState.guessing == 0) {
                                querySpecification.HavingClause = havingClause;
                            }
                            goto IL_100f;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 87:
                    case 92:
                        goto IL_100f;
                }
            } else {
                switch (num3) {
                    case 95:
                    case 106:
                    case 111:
                    case 113:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_100f;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_100f:
            return querySpecification;
            IL_0739:
            FromClause fromClause = this.fromClauseOpt();
            if (base.inputState.guessing == 0) {
                querySpecification.FromClause = fromClause;
            }
            int num4 = this.LA(1);
            if (num4 <= 92) {
                switch (num4) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 82:
                    case 86:
                    case 87:
                    case 92:
                        goto IL_0a46;
                }
            } else {
                switch (num4) {
                    case 169: {
                            WhereClause whereClause = this.whereClause();
                            if (base.inputState.guessing == 0) {
                                querySpecification.WhereClause = whereClause;
                            }
                            goto IL_0a46;
                        }
                    case 95:
                    case 106:
                    case 111:
                    case 113:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0a46;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public QueryParenthesisExpression queryParenthesis(SelectStatement vSelectStatement) {
            QueryParenthesisExpression queryParenthesisExpression = base.FragmentFactory.CreateFragment<QueryParenthesisExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(queryParenthesisExpression, token);
            }
            QueryExpression queryExpression = this.queryExpression(vSelectStatement);
            if (base.inputState.guessing == 0) {
                queryParenthesisExpression.QueryExpression = queryExpression;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(queryParenthesisExpression, token2);
            }
            return queryParenthesisExpression;
        }

        public UniqueRowFilter uniqueRowFilter() {
            UniqueRowFilter result = UniqueRowFilter.NotSpecified;
            switch (this.LA(1)) {
                case 5:
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        result = UniqueRowFilter.All;
                    }
                    break;
                case 51:
                    this.match(51);
                    if (base.inputState.guessing == 0) {
                        result = UniqueRowFilter.Distinct;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public TopRowFilter topRowFilter() {
            TopRowFilter topRowFilter = base.FragmentFactory.CreateFragment<TopRowFilter>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(152);
            ScalarExpression scalarExpression = this.integerOrRealOrNumeric();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(topRowFilter, token);
                topRowFilter.Expression = scalarExpression;
            }
            switch (this.LA(1)) {
                case 116:
                    token2 = this.LT(1);
                    this.match(116);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.ThrowIfPercentValueOutOfRange(scalarExpression);
                        TSql80ParserBaseInternal.UpdateTokenInfo(topRowFilter, token2);
                        topRowFilter.Percent = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 171:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            switch (this.LA(1)) {
                case 171:
                    this.match(171);
                    token3 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token3, "TIES");
                        TSql80ParserBaseInternal.UpdateTokenInfo(topRowFilter, token3);
                        topRowFilter.WithTies = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 79:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            return topRowFilter;
        }

        public SelectElement selectColumnOrStarExpression() {
            bool flag = false;
            if (TSql80ParserInternal.tokenSet_35_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_36_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.selectStarExpression();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                return this.selectStarExpression();
            }
            if (TSql80ParserInternal.tokenSet_37_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_38_.member(this.LA(2))) {
                return this.selectColumn();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public FromClause fromClauseOpt() {
            FromClause result = null;
            int num = this.LA(1);
            if (num <= 87) {
                switch (num) {
                    case 71:
                        result = this.fromClause();
                        goto IL_02bd;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 82:
                    case 86:
                    case 87:
                        goto IL_02bd;
                }
            } else {
                switch (num) {
                    case 92:
                    case 95:
                    case 106:
                    case 111:
                    case 113:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 169:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02bd;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02bd:
            return result;
        }

        public WhereClause whereClause() {
            WhereClause whereClause = base.FragmentFactory.CreateFragment<WhereClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(169);
            BooleanExpression searchCondition = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(whereClause, token);
                whereClause.SearchCondition = searchCondition;
            }
            return whereClause;
        }

        public GroupByClause groupByClause() {
            GroupByClause groupByClause = base.FragmentFactory.CreateFragment<GroupByClause>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(76);
            this.match(18);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(groupByClause, token);
            }
            switch (this.LA(1)) {
                case 5:
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        groupByClause.All = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    break;
            }
            ExpressionGroupingSpecification item = this.simpleGroupByItem();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(groupByClause, groupByClause.GroupingSpecifications, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.simpleGroupByItem();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(groupByClause, groupByClause.GroupingSpecifications, item);
                }
            }
            bool flag = false;
            if (this.LA(1) == 171 && this.LA(2) == 232) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(171);
                    this.match(232);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                this.match(171);
                token2 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    if (groupByClause.All) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46084", token2, TSqlParserResource.SQL46084Message);
                    }
                    TSql80ParserBaseInternal.UpdateTokenInfo(groupByClause, token2);
                    groupByClause.GroupByOption = GroupByOptionHelper.Instance.ParseOption(token2);
                }
                goto IL_037c;
            }
            if (TSql80ParserInternal.tokenSet_39_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_40_.member(this.LA(2))) {
                goto IL_037c;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_037c:
            return groupByClause;
        }

        public HavingClause havingClause() {
            HavingClause havingClause = base.FragmentFactory.CreateFragment<HavingClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(77);
            BooleanExpression searchCondition = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(havingClause, token);
                havingClause.SearchCondition = searchCondition;
            }
            return havingClause;
        }

        public BrowseForClause browseForClause() {
            BrowseForClause browseForClause = base.FragmentFactory.CreateFragment<BrowseForClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(16);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(browseForClause, token);
            }
            return browseForClause;
        }

        public void selectExpression(QuerySpecification vParent) {
            bool flag = false;
            if (this.LA(1) == 234 && this.LA(2) == 206) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(234);
                    this.match(206);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                SelectSetVariable item = this.selectSetVariable();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.SelectElements, item);
                }
                return;
            }
            bool flag2 = false;
            if (TSql80ParserInternal.tokenSet_35_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_41_.member(this.LA(2))) {
                int pos2 = this.mark();
                flag2 = true;
                base.inputState.guessing++;
                try {
                    this.selectStarExpression();
                } catch (RecognitionException) {
                    flag2 = false;
                }
                this.rewind(pos2);
                base.inputState.guessing--;
            }
            if (flag2) {
                SelectStarExpression item2 = this.selectStarExpression();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.SelectElements, item2);
                }
                return;
            }
            if (TSql80ParserInternal.tokenSet_37_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_42_.member(this.LA(2))) {
                SelectScalarExpression item3 = this.selectColumn();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.SelectElements, item3);
                }
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public Literal integerOrRealOrNumeric() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 223:
                    return this.real();
                case 222:
                    return this.numeric();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public SelectSetVariable selectSetVariable() {
            SelectSetVariable selectSetVariable = base.FragmentFactory.CreateFragment<SelectSetVariable>();
            VariableReference variable = this.variable();
            this.match(206);
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                selectSetVariable.Variable = variable;
                selectSetVariable.Expression = expression;
            }
            return selectSetVariable;
        }

        public SelectStarExpression selectStarExpression() {
            SelectStarExpression selectStarExpression = base.FragmentFactory.CreateFragment<SelectStarExpression>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        MultiPartIdentifier qualifier = this.multiPartIdentifier(-1);
                        if (base.inputState.guessing == 0) {
                            selectStarExpression.Qualifier = qualifier;
                        }
                        this.match(200);
                        token = this.LT(1);
                        this.match(195);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(selectStarExpression, token);
                        }
                        break;
                    }
                case 195:
                    token2 = this.LT(1);
                    this.match(195);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(selectStarExpression, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckStarQualifier(selectStarExpression);
            }
            return selectStarExpression;
        }

        public SelectScalarExpression selectColumn() {
            SelectScalarExpression selectScalarExpression = base.FragmentFactory.CreateFragment<SelectScalarExpression>();
            if (TSql80ParserInternal.tokenSet_37_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_43_.member(this.LA(2))) {
                ScalarExpression expression = this.selectColumnExpression();
                if (base.inputState.guessing == 0) {
                    selectScalarExpression.Expression = expression;
                }
                int num = this.LA(1);
                if (num <= 95) {
                    switch (num) {
                        case 9:
                            break;
                        default:
                            goto IL_03ab;
                        case 1:
                        case 6:
                        case 12:
                        case 13:
                        case 15:
                        case 17:
                        case 22:
                        case 23:
                        case 28:
                        case 29:
                        case 33:
                        case 35:
                        case 44:
                        case 45:
                        case 46:
                        case 48:
                        case 49:
                        case 54:
                        case 55:
                        case 56:
                        case 59:
                        case 60:
                        case 61:
                        case 64:
                        case 67:
                        case 71:
                        case 74:
                        case 75:
                        case 76:
                        case 77:
                        case 82:
                        case 86:
                        case 87:
                        case 88:
                        case 92:
                        case 95:
                            goto IL_043e;
                    }
                } else {
                    switch (num) {
                        case 230:
                        case 231:
                        case 232:
                        case 233:
                            break;
                        default:
                            goto IL_03ab;
                        case 106:
                        case 111:
                        case 113:
                        case 119:
                        case 123:
                        case 125:
                        case 126:
                        case 129:
                        case 131:
                        case 132:
                        case 134:
                        case 138:
                        case 140:
                        case 142:
                        case 143:
                        case 144:
                        case 156:
                        case 158:
                        case 160:
                        case 161:
                        case 162:
                        case 167:
                        case 169:
                        case 170:
                        case 171:
                        case 172:
                        case 173:
                        case 176:
                        case 180:
                        case 181:
                        case 191:
                        case 192:
                        case 198:
                        case 204:
                        case 219:
                        case 220:
                            goto IL_043e;
                    }
                }
                switch (this.LA(1)) {
                    case 9:
                        this.match(9);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 230:
                    case 231:
                    case 232:
                    case 233:
                        break;
                }
                IdentifierOrValueExpression columnName = this.stringOrIdentifier();
                if (base.inputState.guessing == 0) {
                    selectScalarExpression.ColumnName = columnName;
                }
                goto IL_043e;
            }
            if (this.LA(1) >= 230 && this.LA(1) <= 233 && this.LA(2) == 206) {
                IdentifierOrValueExpression columnName = this.stringOrIdentifier();
                if (base.inputState.guessing == 0) {
                    selectScalarExpression.ColumnName = columnName;
                }
                this.match(206);
                ScalarExpression expression = this.selectColumnExpression();
                if (base.inputState.guessing == 0) {
                    selectScalarExpression.Expression = expression;
                }
                goto IL_043e;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_03ab:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_043e:
            return selectScalarExpression;
        }

        public ScalarExpression selectColumnExpression() {
            ScalarExpression scalarExpression = null;
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    return this.expression();
                case 79:
                    return this.identityFunction();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public MultiPartIdentifier multiPartIdentifier(int vMaxNumber) {
            MultiPartIdentifier multiPartIdentifier = base.FragmentFactory.CreateFragment<MultiPartIdentifier>();
            List<Identifier> otherCollection = this.identifierList(vMaxNumber);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(multiPartIdentifier, multiPartIdentifier.Identifiers, otherCollection);
            }
            return multiPartIdentifier;
        }

        public IdentityFunctionCall identityFunction() {
            IdentityFunctionCall identityFunctionCall = base.FragmentFactory.CreateFragment<IdentityFunctionCall>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(79);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identityFunctionCall, token);
            }
            this.match(191);
            DataTypeReference dataType = this.scalarDataType();
            if (base.inputState.guessing == 0) {
                identityFunctionCall.DataType = dataType;
            }
            switch (this.LA(1)) {
                case 198: {
                        this.match(198);
                        ScalarExpression seed = this.seedIncrement();
                        if (base.inputState.guessing == 0) {
                            identityFunctionCall.Seed = seed;
                        }
                        this.match(198);
                        seed = this.seedIncrement();
                        if (base.inputState.guessing == 0) {
                            identityFunctionCall.Increment = seed;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identityFunctionCall, token2);
            }
            return identityFunctionCall;
        }

        public ScalarExpression seedIncrement() {
            ScalarExpression result = null;
            IToken token = null;
            IToken token2 = null;
            UnaryExpression unaryExpression = null;
            switch (this.LA(1)) {
                case 199:
                    token = this.LT(1);
                    this.match(199);
                    if (base.inputState.guessing == 0) {
                        unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                        TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token);
                        unaryExpression.UnaryExpressionType = UnaryExpressionType.Negative;
                    }
                    break;
                case 197:
                    token2 = this.LT(1);
                    this.match(197);
                    if (base.inputState.guessing == 0) {
                        unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                        TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token2);
                        unaryExpression.UnaryExpressionType = UnaryExpressionType.Positive;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 221:
                case 222:
                    break;
            }
            Literal literal = this.integerOrNumeric();
            if (base.inputState.guessing == 0) {
                if (unaryExpression != null) {
                    unaryExpression.Expression = literal;
                    result = unaryExpression;
                } else {
                    result = literal;
                }
            }
            return result;
        }

        public FromClause fromClause() {
            FromClause fromClause = base.FragmentFactory.CreateFragment<FromClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(71);
            TableReference item = this.selectTableReferenceWithOdbc();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fromClause, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fromClause, fromClause.TableReferences, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.selectTableReferenceWithOdbc();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fromClause, fromClause.TableReferences, item);
                }
            }
            return fromClause;
        }

        public TableReference selectTableReferenceWithOdbc() {
            TableReference tableReference = null;
            switch (this.LA(1)) {
                case 32:
                case 70:
                case 107:
                case 108:
                case 109:
                case 110:
                case 191:
                case 200:
                case 203:
                case 232:
                case 233:
                case 234:
                    return this.selectTableReference();
                case 193:
                case 235:
                    return this.odbcQualifiedJoin();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TableReference selectTableReference() {
            TableReference result = null;
            result = this.selectTableReferenceElement();
            while (true) {
                if (!TSql80ParserInternal.tokenSet_44_.member(this.LA(1))) {
                    break;
                }
                this.joinElement(ref result);
            }
            return result;
        }

        public OdbcQualifiedJoinTableReference odbcQualifiedJoin() {
            OdbcQualifiedJoinTableReference odbcQualifiedJoinTableReference = base.FragmentFactory.CreateFragment<OdbcQualifiedJoinTableReference>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            switch (this.LA(1)) {
                case 193:
                    token = this.LT(1);
                    this.match(193);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(odbcQualifiedJoinTableReference, token);
                    }
                    break;
                case 235:
                    this.odbcInitiator();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token2, "OJ");
            }
            TableReference tableReference;
            switch (this.LA(1)) {
                case 193:
                case 235:
                    tableReference = this.odbcQualifiedJoin();
                    break;
                case 32:
                case 70:
                case 107:
                case 108:
                case 109:
                case 110:
                case 191:
                case 200:
                case 203:
                case 232:
                case 233:
                case 234:
                    tableReference = this.selectTableReference();
                    if (base.inputState.guessing == 0 && !(tableReference is QualifiedJoin)) {
                        TSql80ParserBaseInternal.ThrowParseErrorException("SQL46035", token, TSqlParserResource.SQL46035Message);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                odbcQualifiedJoinTableReference.TableReference = tableReference;
            }
            token3 = this.LT(1);
            this.match(194);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(odbcQualifiedJoinTableReference, token3);
            }
            return odbcQualifiedJoinTableReference;
        }

        public TableReference selectTableReferenceElement() {
            TableReference tableReference = null;
            bool flag = false;
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_45_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.joinParenthesis();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                return this.joinParenthesis();
            }
            if (TSql80ParserInternal.tokenSet_45_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_46_.member(this.LA(2))) {
                return this.selectTableReferenceElementWithOutJoinParenthesis();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void joinElement(ref TableReference vResult) {
            switch (this.LA(1)) {
                case 36:
                case 114:
                    this.unqualifiedJoin(ref vResult);
                    break;
                case 72:
                case 85:
                case 90:
                case 93:
                case 133:
                    this.qualifiedJoin(ref vResult);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void odbcInitiator() {
            IToken token = null;
            token = this.LT(1);
            this.match(235);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46036", token, TSqlParserResource.SQL46036Message);
            }
        }

        public OdbcConvertSpecification odbcConvertSpecification() {
            OdbcConvertSpecification odbcConvertSpecification = base.FragmentFactory.CreateFragment<OdbcConvertSpecification>();
            Identifier identifier = this.nonQuotedIdentifier();
            if (base.inputState.guessing == 0) {
                odbcConvertSpecification.Identifier = identifier;
            }
            return odbcConvertSpecification;
        }

        public ExtractFromExpression extractFromExpression() {
            ExtractFromExpression extractFromExpression = base.FragmentFactory.CreateFragment<ExtractFromExpression>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(191);
            Identifier extractedElement = this.identifier();
            this.match(71);
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "EXTRACT");
                extractFromExpression.Expression = expression;
                extractFromExpression.ExtractedElement = extractedElement;
            }
            this.match(192);
            return extractFromExpression;
        }

        public OdbcFunctionCall odbcFunctionCall() {
            OdbcFunctionCall odbcFunctionCall = base.FragmentFactory.CreateFragment<OdbcFunctionCall>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            Identifier identifier = base.FragmentFactory.CreateFragment<Identifier>();
            odbcFunctionCall.ParametersUsed = true;
            token = this.LT(1);
            this.match(193);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(odbcFunctionCall, token);
            }
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token2, "FN");
            }
            if (base.inputState.guessing == 0 && this.LA(1) != 1) {
                identifier.SetUnquotedIdentifier(this.LT(1).getText());
                odbcFunctionCall.Name = identifier;
            }
            switch (this.LA(1)) {
                case 34: {
                        this.match(34);
                        this.match(191);
                        ScalarExpression item = this.expression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(odbcFunctionCall, odbcFunctionCall.Parameters, item);
                        }
                        this.match(198);
                        item = this.odbcConvertSpecification();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(odbcFunctionCall, odbcFunctionCall.Parameters, item);
                        }
                        this.match(192);
                        break;
                    }
                case 156: {
                        this.match(156);
                        this.match(191);
                        ScalarExpression item = this.expression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(odbcFunctionCall, odbcFunctionCall.Parameters, item);
                        }
                        this.match(198);
                        item = this.expression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(odbcFunctionCall, odbcFunctionCall.Parameters, item);
                        }
                        this.match(192);
                        break;
                    }
                case 38:
                case 43:
                case 163:
                    switch (this.LA(1)) {
                        case 43:
                            this.match(43);
                            break;
                        case 163:
                            this.match(163);
                            break;
                        case 38:
                            this.match(38);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    this.match(191);
                    this.match(192);
                    break;
                case 86:
                case 93:
                case 133:
                    switch (this.LA(1)) {
                        case 86:
                            this.match(86);
                            break;
                        case 93:
                            this.match(93);
                            break;
                        case 133:
                            this.match(133);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    this.match(191);
                    this.expressionList(odbcFunctionCall, odbcFunctionCall.Parameters);
                    this.match(192);
                    break;
                case 39:
                case 40:
                    switch (this.LA(1)) {
                        case 39:
                            this.match(39);
                            break;
                        case 40:
                            this.match(40);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    switch (this.LA(1)) {
                        case 191:
                            this.match(191);
                            switch (this.LA(1)) {
                                case 20:
                                case 25:
                                case 34:
                                case 40:
                                case 41:
                                case 81:
                                case 93:
                                case 100:
                                case 101:
                                case 133:
                                case 136:
                                case 141:
                                case 147:
                                case 163:
                                case 191:
                                case 193:
                                case 197:
                                case 199:
                                case 200:
                                case 211:
                                case 221:
                                case 222:
                                case 223:
                                case 224:
                                case 225:
                                case 227:
                                case 228:
                                case 230:
                                case 231:
                                case 232:
                                case 233:
                                case 234:
                                case 235:
                                    this.expressionList(odbcFunctionCall, odbcFunctionCall.Parameters);
                                    break;
                                default:
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                                case 192:
                                    break;
                            }
                            this.match(192);
                            break;
                        case 194:
                            if (base.inputState.guessing == 0) {
                                odbcFunctionCall.ParametersUsed = false;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    if (this.LA(1) == 232 && this.LA(2) == 191 && base.NextTokenMatches("EXTRACT")) {
                        ScalarExpression item = this.extractFromExpression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(odbcFunctionCall, odbcFunctionCall.Parameters, item);
                        }
                        break;
                    }
                    if (this.LA(1) == 232 && this.LA(2) == 191) {
                        this.match(232);
                        this.match(191);
                        switch (this.LA(1)) {
                            case 20:
                            case 25:
                            case 34:
                            case 40:
                            case 41:
                            case 81:
                            case 93:
                            case 100:
                            case 101:
                            case 133:
                            case 136:
                            case 141:
                            case 147:
                            case 163:
                            case 191:
                            case 193:
                            case 197:
                            case 199:
                            case 200:
                            case 211:
                            case 221:
                            case 222:
                            case 223:
                            case 224:
                            case 225:
                            case 227:
                            case 228:
                            case 230:
                            case 231:
                            case 232:
                            case 233:
                            case 234:
                            case 235:
                                this.expressionList(odbcFunctionCall, odbcFunctionCall.Parameters);
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 192:
                                break;
                        }
                        this.match(192);
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token3 = this.LT(1);
            this.match(194);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(odbcFunctionCall, token3);
            }
            return odbcFunctionCall;
        }

        public void expressionList(TSqlFragment vParent, IList<ScalarExpression> expressions) {
            ScalarExpression item = this.expression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, expressions, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.expression();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, expressions, item);
                }
            }
        }

        public TableReference joinTableReference() {
            TableReference result = null;
            IToken marker = null;
            bool flag = false;
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_45_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    if (!base.SkipGuessing(marker)) {
                        result = this.joinParenthesis();
                    }
                    base.SaveGuessing(out marker);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                if (!base.SkipGuessing(marker)) {
                    result = this.joinParenthesis();
                }
                while (true) {
                    if (!TSql80ParserInternal.tokenSet_44_.member(this.LA(1))) {
                        break;
                    }
                    this.joinElement(ref result);
                }
                goto IL_0130;
            }
            if (TSql80ParserInternal.tokenSet_45_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_47_.member(this.LA(2))) {
                result = this.selectTableReferenceElementWithOutJoinParenthesis();
                int num = 0;
                while (true) {
                    if (!TSql80ParserInternal.tokenSet_44_.member(this.LA(1))) {
                        break;
                    }
                    this.joinElement(ref result);
                    num++;
                }
                if (num < 1) {
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                goto IL_0130;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0130:
            return result;
        }

        public JoinParenthesisTableReference joinParenthesis() {
            JoinParenthesisTableReference joinParenthesisTableReference = base.FragmentFactory.CreateFragment<JoinParenthesisTableReference>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            TableReference join = this.joinTableReference();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(joinParenthesisTableReference, token);
                joinParenthesisTableReference.Join = join;
                TSql80ParserBaseInternal.UpdateTokenInfo(joinParenthesisTableReference, token2);
            }
            return joinParenthesisTableReference;
        }

        public TableReference selectTableReferenceElementWithOutJoinParenthesis() {
            TableReference tableReference = null;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233:
                    return this.schemaObjectOrFunctionTableReference();
                case 203:
                    return this.builtInFunctionTableReference();
                case 234:
                    return this.variableTableReference();
                case 191:
                    return this.derivedTable();
                case 107:
                case 108:
                case 109:
                    return this.openRowset();
                case 32:
                case 70:
                    return this.fulltextTableReference();
                case 110:
                    return this.openXmlTableReference();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void unqualifiedJoin(ref TableReference vResult) {
            IToken token = null;
            IToken token2 = null;
            UnqualifiedJoin unqualifiedJoin = base.FragmentFactory.CreateFragment<UnqualifiedJoin>();
            switch (this.LA(1)) {
                case 36:
                    this.match(36);
                    switch (this.LA(1)) {
                        case 90:
                            this.match(90);
                            if (base.inputState.guessing == 0) {
                                unqualifiedJoin.UnqualifiedJoinType = UnqualifiedJoinType.CrossJoin;
                            }
                            break;
                        case 232:
                            token = this.LT(1);
                            this.match(232);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.Match(token, "APPLY");
                                unqualifiedJoin.UnqualifiedJoinType = UnqualifiedJoinType.CrossApply;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                case 114:
                    this.match(114);
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "APPLY");
                        unqualifiedJoin.UnqualifiedJoinType = UnqualifiedJoinType.OuterApply;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            TableReference secondTableReference = this.selectTableReferenceElement();
            if (base.inputState.guessing == 0) {
                unqualifiedJoin.FirstTableReference = vResult;
                unqualifiedJoin.SecondTableReference = secondTableReference;
                vResult = unqualifiedJoin;
            }
        }

        public void qualifiedJoin(ref TableReference vResult) {
            QualifiedJoin qualifiedJoin = base.FragmentFactory.CreateFragment<QualifiedJoin>();
            switch (this.LA(1)) {
                case 90:
                    this.match(90);
                    if (base.inputState.guessing == 0) {
                        qualifiedJoin.QualifiedJoinType = QualifiedJoinType.Inner;
                    }
                    break;
                case 72:
                case 85:
                case 93:
                case 133:
                    switch (this.LA(1)) {
                        case 85:
                            this.match(85);
                            if (base.inputState.guessing == 0) {
                                qualifiedJoin.QualifiedJoinType = QualifiedJoinType.Inner;
                            }
                            break;
                        case 93:
                            this.match(93);
                            switch (this.LA(1)) {
                                case 114:
                                    this.match(114);
                                    break;
                                default:
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                                case 90:
                                case 232:
                                    break;
                            }
                            if (base.inputState.guessing == 0) {
                                qualifiedJoin.QualifiedJoinType = QualifiedJoinType.LeftOuter;
                            }
                            break;
                        case 133:
                            this.match(133);
                            switch (this.LA(1)) {
                                case 114:
                                    this.match(114);
                                    break;
                                default:
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                                case 90:
                                case 232:
                                    break;
                            }
                            if (base.inputState.guessing == 0) {
                                qualifiedJoin.QualifiedJoinType = QualifiedJoinType.RightOuter;
                            }
                            break;
                        case 72:
                            this.match(72);
                            switch (this.LA(1)) {
                                case 114:
                                    this.match(114);
                                    break;
                                default:
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                                case 90:
                                case 232:
                                    break;
                            }
                            if (base.inputState.guessing == 0) {
                                qualifiedJoin.QualifiedJoinType = QualifiedJoinType.FullOuter;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    switch (this.LA(1)) {
                        case 232:
                            this.joinHint(qualifiedJoin);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 90:
                            break;
                    }
                    this.match(90);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            TableReference secondTableReference = this.selectTableReferenceWithOdbc();
            if (base.inputState.guessing == 0) {
                qualifiedJoin.FirstTableReference = vResult;
                qualifiedJoin.SecondTableReference = secondTableReference;
            }
            this.match(105);
            BooleanExpression searchCondition = this.booleanExpression();
            if (base.inputState.guessing == 0) {
                qualifiedJoin.SearchCondition = searchCondition;
                vResult = qualifiedJoin;
            }
        }

        public TableReference schemaObjectOrFunctionTableReference() {
            SchemaObjectName vSchemaObjectName = this.schemaObjectFourPartName();
            if (TSql80ParserInternal.tokenSet_48_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_49_.member(this.LA(2)) && base.IsTableReference(true)) {
                return this.schemaObjectTableReference(vSchemaObjectName);
            }
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_50_.member(this.LA(2))) {
                return this.schemaObjectFunctionTableReference(vSchemaObjectName);
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public BuiltInFunctionTableReference builtInFunctionTableReference() {
            BuiltInFunctionTableReference builtInFunctionTableReference = base.FragmentFactory.CreateFragment<BuiltInFunctionTableReference>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(203);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(builtInFunctionTableReference, token);
            }
            Identifier name = this.identifier();
            if (base.inputState.guessing == 0) {
                builtInFunctionTableReference.Name = name;
            }
            this.match(191);
            switch (this.LA(1)) {
                case 47:
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 234: {
                        ScalarExpression item = this.possibleNegativeConstantWithDefault();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(builtInFunctionTableReference, builtInFunctionTableReference.Parameters, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.possibleNegativeConstantWithDefault();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(builtInFunctionTableReference, builtInFunctionTableReference.Parameters, item);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(builtInFunctionTableReference, token2);
            }
            this.simpleTableReferenceAliasOpt(builtInFunctionTableReference);
            return builtInFunctionTableReference;
        }

        public VariableTableReference variableTableReference() {
            VariableTableReference variableTableReference = base.FragmentFactory.CreateFragment<VariableTableReference>();
            VariableReference variable = this.variable();
            if (base.inputState.guessing == 0) {
                variableTableReference.Variable = variable;
            }
            this.simpleTableReferenceAliasOpt(variableTableReference);
            return variableTableReference;
        }

        public TableReferenceWithAlias openRowset() {
            TableReferenceWithAlias tableReferenceWithAlias;
            switch (this.LA(1)) {
                case 109:
                    tableReferenceWithAlias = this.openRowsetRowset();
                    break;
                case 108:
                    tableReferenceWithAlias = this.openQueryRowset();
                    this.simpleTableReferenceAliasOpt(tableReferenceWithAlias);
                    break;
                case 107:
                    tableReferenceWithAlias = this.adhocRowset();
                    this.simpleTableReferenceAliasOpt(tableReferenceWithAlias);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return tableReferenceWithAlias;
        }

        public FullTextTableReference fulltextTableReference() {
            FullTextTableReference fullTextTableReference = base.FragmentFactory.CreateFragment<FullTextTableReference>();
            IToken token = null;
            this.fullTextTable(fullTextTableReference);
            this.match(191);
            SchemaObjectName tableName = this.schemaObjectFourPartName();
            if (base.inputState.guessing == 0) {
                fullTextTableReference.TableName = tableName;
            }
            this.match(198);
            this.fulltextTableColumnList(fullTextTableReference);
            this.match(198);
            ValueExpression searchCondition = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                fullTextTableReference.SearchCondition = searchCondition;
            }
            switch (this.LA(1)) {
                case 198:
                    this.fulltextTableOptions(fullTextTableReference);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fullTextTableReference, token);
            }
            this.simpleTableReferenceAliasOpt(fullTextTableReference);
            return fullTextTableReference;
        }

        public OpenXmlTableReference openXmlTableReference() {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(110);
            this.match(191);
            OpenXmlTableReference openXmlTableReference = this.openXmlParams();
            token2 = this.LT(1);
            this.match(192);
            this.openXmlWithClauseOpt(openXmlTableReference);
            this.simpleTableReferenceAliasOpt(openXmlTableReference);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(openXmlTableReference, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(openXmlTableReference, token2);
            }
            return openXmlTableReference;
        }

        public void joinHint(QualifiedJoin vParent) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            switch (this.LA(1)) {
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token, "LOCAL");
                        vParent.JoinHint = JoinHintHelper.Instance.ParseOption(token2);
                        if (vParent.JoinHint == JoinHint.Remote) {
                            TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(token2);
                        }
                    }
                    break;
                case 90:
                    if (base.inputState.guessing == 0) {
                        vParent.JoinHint = JoinHintHelper.Instance.ParseOption(token);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ScalarExpression possibleNegativeConstantWithDefault() {
            ScalarExpression scalarExpression = null;
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 234:
                    return this.possibleNegativeConstant();
                case 47:
                    return this.defaultLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void simpleTableReferenceAliasOpt(TableReferenceWithAlias vParent) {
            int num = this.LA(1);
            if (num <= 106) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 36:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 71:
                    case 72:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 82:
                    case 85:
                    case 86:
                    case 87:
                    case 90:
                    case 92:
                    case 93:
                    case 95:
                    case 105:
                    case 106:
                        return;
                    case 9:
                        break;
                    default:
                        goto IL_030f;
                }
            } else {
                switch (num) {
                    case 111:
                    case 113:
                    case 114:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 133:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 164:
                    case 167:
                    case 169:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 194:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 232:
                    case 233:
                        break;
                    default:
                        goto IL_030f;
                }
            }
            this.simpleTableReferenceAlias(vParent);
            return;
            IL_030f:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public RaiseErrorStatement raiseErrorStatement() {
            RaiseErrorStatement raiseErrorStatement = base.FragmentFactory.CreateFragment<RaiseErrorStatement>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(raiseErrorStatement, token);
            }
            ScalarExpression firstParameter = this.signedIntegerOrStringOrVariable();
            if (base.inputState.guessing == 0) {
                raiseErrorStatement.FirstParameter = firstParameter;
            }
            this.match(198);
            firstParameter = this.signedIntegerOrVariable();
            if (base.inputState.guessing == 0) {
                raiseErrorStatement.SecondParameter = firstParameter;
            }
            this.match(198);
            firstParameter = this.signedIntegerOrVariable();
            if (base.inputState.guessing == 0) {
                raiseErrorStatement.ThirdParameter = firstParameter;
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                firstParameter = this.possibleNegativeConstant();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(raiseErrorStatement, raiseErrorStatement.OptionalParameters, firstParameter);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(raiseErrorStatement, token2);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0438;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token3 = this.LT(1);
                        this.match(232);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(raiseErrorStatement, token3);
                            raiseErrorStatement.RaiseErrorOptions |= RaiseErrorOptionsHelper.Instance.ParseOption(token3);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            token4 = this.LT(1);
                            this.match(232);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(raiseErrorStatement, token4);
                                raiseErrorStatement.RaiseErrorOptions |= RaiseErrorOptionsHelper.Instance.ParseOption(token4);
                            }
                        }
                        goto IL_0438;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0438;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0438:
            return raiseErrorStatement;
        }

        public RaiseErrorLegacyStatement raiseErrorLegacyStatement() {
            RaiseErrorLegacyStatement raiseErrorLegacyStatement = base.FragmentFactory.CreateFragment<RaiseErrorLegacyStatement>();
            ScalarExpression firstParameter = this.signedIntegerOrVariable();
            if (base.inputState.guessing == 0) {
                raiseErrorLegacyStatement.FirstParameter = firstParameter;
            }
            ValueExpression secondParameter = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                raiseErrorLegacyStatement.SecondParameter = secondParameter;
            }
            return raiseErrorLegacyStatement;
        }

        public ScalarExpression signedIntegerOrStringOrVariable() {
            switch (this.LA(1)) {
                case 199:
                case 221:
                    return this.signedInteger();
                case 230:
                case 231:
                case 234:
                    return this.stringOrVariable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ScalarExpression possibleNegativeConstant() {
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 234:
                    return this.literal();
                case 199:
                    return this.negativeConstant();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public DeleteSpecification deleteSpecification() {
            DeleteSpecification deleteSpecification = base.FragmentFactory.CreateFragment<DeleteSpecification>();
            IToken token = null;
            token = this.LT(1);
            this.match(48);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(deleteSpecification, token);
            }
            switch (this.LA(1)) {
                case 71:
                    this.match(71);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 107:
                case 108:
                case 109:
                case 200:
                case 232:
                case 233:
                case 234:
                    break;
            }
            TableReference target = this.dmlTarget();
            if (base.inputState.guessing == 0) {
                deleteSpecification.Target = target;
            }
            FromClause fromClause = this.fromClauseOpt();
            if (base.inputState.guessing == 0) {
                deleteSpecification.FromClause = fromClause;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0372;
                }
            } else {
                switch (num) {
                    case 169: {
                            WhereClause whereClause = this.dmlWhereClause();
                            if (base.inputState.guessing == 0) {
                                deleteSpecification.WhereClause = whereClause;
                            }
                            goto IL_0372;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0372;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0372:
            return deleteSpecification;
        }

        public TableReference dmlTarget() {
            TableReference tableReference = null;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233:
                    return this.schemaObjectDmlTarget();
                case 107:
                case 108:
                case 109:
                    return this.openRowset();
                case 234:
                    return this.variableDmlTarget();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public WhereClause dmlWhereClause() {
            if (this.LA(1) == 169 && TSql80ParserInternal.tokenSet_51_.member(this.LA(2))) {
                return this.whereClause();
            }
            if (this.LA(1) == 169 && this.LA(2) == 37) {
                return this.whereCurrentOfCursorClause();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public InsertSpecification insertSpecification() {
            InsertSpecification insertSpecification = base.FragmentFactory.CreateFragment<InsertSpecification>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            InsertSource insertSource = null;
            token = this.LT(1);
            this.match(86);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(insertSpecification, token);
            }
            switch (this.LA(1)) {
                case 88:
                    this.match(88);
                    if (base.inputState.guessing == 0) {
                        insertSpecification.InsertOption = InsertOption.Into;
                    }
                    break;
                case 115:
                    this.match(115);
                    if (base.inputState.guessing == 0) {
                        insertSpecification.InsertOption = InsertOption.Over;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 107:
                case 108:
                case 109:
                case 200:
                case 232:
                case 233:
                case 234:
                    break;
            }
            TableReference target = this.dmlTarget();
            if (base.inputState.guessing == 0) {
                insertSpecification.Target = target;
            }
            bool flag = false;
            if (this.LA(1) == 191 && (this.LA(2) == 200 || this.LA(2) == 232 || this.LA(2) == 233)) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    switch (this.LA(1)) {
                        case 200:
                            this.match(200);
                            break;
                        case 232:
                            this.match(232);
                            break;
                        case 233:
                            this.match(233);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                token2 = this.LT(1);
                this.match(191);
                ColumnReferenceExpression item = this.insertColumn();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(insertSpecification, token2);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(insertSpecification, insertSpecification.Columns, item);
                }
                while (true) {
                    if (this.LA(1) != 198) {
                        break;
                    }
                    this.match(198);
                    item = this.insertColumn();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(insertSpecification, insertSpecification.Columns, item);
                    }
                }
                token3 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(insertSpecification, token3);
                }
                goto IL_02d0;
            }
            if (TSql80ParserInternal.tokenSet_52_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_53_.member(this.LA(2))) {
                goto IL_02d0;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02d0:
            switch (this.LA(1)) {
                case 47:
                case 164:
                    insertSource = this.valuesInsertSource();
                    break;
                case 60:
                case 61:
                    insertSource = this.executeInsertSource();
                    break;
                case 140:
                case 191:
                    insertSource = this.selectInsertSource();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                insertSpecification.InsertSource = insertSource;
            }
            return insertSpecification;
        }

        public ColumnReferenceExpression insertColumn() {
            ColumnReferenceExpression columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            MultiPartIdentifier multiPartIdentifier = this.multiPartIdentifier(-1);
            if (base.inputState.guessing == 0) {
                columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
            }
            return columnReferenceExpression;
        }

        public ValuesInsertSource valuesInsertSource() {
            ValuesInsertSource valuesInsertSource = base.FragmentFactory.CreateFragment<ValuesInsertSource>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 47:
                    this.match(47);
                    token = this.LT(1);
                    this.match(164);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(valuesInsertSource, token);
                        valuesInsertSource.IsDefaultValues = true;
                    }
                    break;
                case 164: {
                        token2 = this.LT(1);
                        this.match(164);
                        RowValue item = this.rowValueExpressionWithDefault();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(valuesInsertSource, token2);
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(valuesInsertSource, valuesInsertSource.RowValues, item);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return valuesInsertSource;
        }

        public ExecuteInsertSource executeInsertSource() {
            ExecuteInsertSource executeInsertSource = base.FragmentFactory.CreateFragment<ExecuteInsertSource>();
            ExecuteSpecification execute = this.executeSpecification();
            if (base.inputState.guessing == 0) {
                executeInsertSource.Execute = execute;
            }
            return executeInsertSource;
        }

        public SelectInsertSource selectInsertSource() {
            SelectInsertSource selectInsertSource = base.FragmentFactory.CreateFragment<SelectInsertSource>();
            QueryExpression queryExpression = this.queryExpression(null);
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_02a0;
                }
            } else {
                switch (num) {
                    case 113: {
                            OrderByClause orderByClause = this.orderByClause();
                            if (base.inputState.guessing == 0) {
                                queryExpression.OrderByClause = orderByClause;
                            }
                            goto IL_02a0;
                        }
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02a0;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02a0:
            if (base.inputState.guessing == 0) {
                selectInsertSource.Select = queryExpression;
            }
            return selectInsertSource;
        }

        public UpdateSpecification updateSpecification() {
            UpdateSpecification updateSpecification = base.FragmentFactory.CreateFragment<UpdateSpecification>();
            IToken token = null;
            token = this.LT(1);
            this.match(160);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(updateSpecification, token);
            }
            TableReference target = this.dmlTarget();
            if (base.inputState.guessing == 0) {
                updateSpecification.Target = target;
            }
            this.setClausesList(updateSpecification, updateSpecification.SetClauses);
            FromClause fromClause = this.fromClauseOpt();
            if (base.inputState.guessing == 0) {
                updateSpecification.FromClause = fromClause;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0314;
                }
            } else {
                switch (num) {
                    case 169: {
                            WhereClause whereClause = this.dmlWhereClause();
                            if (base.inputState.guessing == 0) {
                                updateSpecification.WhereClause = whereClause;
                            }
                            goto IL_0314;
                        }
                    case 92:
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0314;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0314:
            return updateSpecification;
        }

        public void setClausesList(TSqlFragment vParent, IList<SetClause> setClauses) {
            IToken token = null;
            token = this.LT(1);
            this.match(142);
            SetClause item = this.setClause();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, setClauses, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.setClause();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, setClauses, item);
                }
            }
        }

        public AssignmentSetClause setClause() {
            AssignmentSetClause assignmentSetClause = base.FragmentFactory.CreateFragment<AssignmentSetClause>();
            switch (this.LA(1)) {
                case 234: {
                        VariableReference variable = this.variable();
                        this.match(206);
                        if (base.inputState.guessing == 0) {
                            assignmentSetClause.Variable = variable;
                        }
                        bool flag = false;
                        if ((this.LA(1) == 200 || this.LA(1) == 232 || this.LA(1) == 233) && TSql80ParserInternal.tokenSet_54_.member(this.LA(2))) {
                            int pos = this.mark();
                            flag = true;
                            base.inputState.guessing++;
                            try {
                                this.identifierList(-1);
                                this.match(206);
                            } catch (RecognitionException) {
                                flag = false;
                            }
                            this.rewind(pos);
                            base.inputState.guessing--;
                        }
                        if (flag) {
                            this.setClauseSubItem(assignmentSetClause);
                            break;
                        }
                        if (TSql80ParserInternal.tokenSet_16_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_55_.member(this.LA(2))) {
                            ScalarExpression newValue = this.expression();
                            if (base.inputState.guessing == 0) {
                                assignmentSetClause.NewValue = newValue;
                            }
                            break;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 200:
                case 232:
                case 233:
                    this.setClauseSubItem(assignmentSetClause);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return assignmentSetClause;
        }

        public void setClauseSubItem(AssignmentSetClause vParent) {
            MultiPartIdentifier multiPartIdentifier = this.multiPartIdentifier(-1);
            if (base.inputState.guessing == 0) {
                base.CreateSetClauseColumn(vParent, multiPartIdentifier);
            }
            this.match(206);
            ScalarExpression newValue = this.expressionWithDefault();
            if (base.inputState.guessing == 0) {
                vParent.NewValue = newValue;
            }
        }

        public ScalarExpression expressionWithDefault() {
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    return this.expression();
                case 47:
                    return this.defaultLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ExecuteSpecification executeSpecification() {
            ExecuteSpecification executeSpecification = base.FragmentFactory.CreateFragment<ExecuteSpecification>();
            this.execStart(executeSpecification);
            this.execTypes(executeSpecification);
            return executeSpecification;
        }

        public RowValue rowValueExpressionWithDefault() {
            RowValue rowValue = base.FragmentFactory.CreateFragment<RowValue>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(rowValue, token);
            }
            this.expressionWithDefaultList(rowValue, rowValue.ColumnValues);
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(rowValue, token2);
            }
            return rowValue;
        }

        public void expressionWithDefaultList(TSqlFragment vParent, IList<ScalarExpression> expressions) {
            ScalarExpression item = this.expressionWithDefault();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, expressions, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.expressionWithDefault();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, expressions, item);
                }
            }
        }

        public TableReferenceWithAlias schemaObjectDmlTarget() {
            TableReferenceWithAlias tableReferenceWithAlias = null;
            bool flag = false;
            if ((this.LA(1) == 200 || this.LA(1) == 232 || this.LA(1) == 233) && TSql80ParserInternal.tokenSet_56_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.schemaObjectFourPartName();
                    this.match(191);
                    switch (this.LA(1)) {
                        case 47:
                        case 100:
                        case 193:
                        case 199:
                        case 221:
                        case 222:
                        case 223:
                        case 224:
                        case 225:
                        case 230:
                        case 231:
                        case 234:
                            this.possibleNegativeConstantWithDefault();
                            break;
                        case 192:
                            this.match(192);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                return this.schemaObjectFunctionDmlTarget();
            }
            if ((this.LA(1) == 200 || this.LA(1) == 232 || this.LA(1) == 233) && TSql80ParserInternal.tokenSet_57_.member(this.LA(2))) {
                return this.schemaObjectTableDmlTarget();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public VariableTableReference variableDmlTarget() {
            VariableTableReference variableTableReference = base.FragmentFactory.CreateFragment<VariableTableReference>();
            VariableReference variable = this.variable();
            if (base.inputState.guessing == 0) {
                variableTableReference.Variable = variable;
            }
            return variableTableReference;
        }

        public SchemaObjectFunctionTableReference schemaObjectFunctionDmlTarget() {
            SchemaObjectFunctionTableReference schemaObjectFunctionTableReference = base.FragmentFactory.CreateFragment<SchemaObjectFunctionTableReference>();
            SchemaObjectName schemaObject = this.schemaObjectFourPartName();
            if (base.inputState.guessing == 0) {
                schemaObjectFunctionTableReference.SchemaObject = schemaObject;
            }
            this.parenthesizedOptExpressionWithDefaultList(schemaObjectFunctionTableReference, schemaObjectFunctionTableReference.Parameters);
            return schemaObjectFunctionTableReference;
        }

        public NamedTableReference schemaObjectTableDmlTarget() {
            NamedTableReference namedTableReference = base.FragmentFactory.CreateFragment<NamedTableReference>();
            SchemaObjectName schemaObject = this.schemaObjectFourPartName();
            if (base.inputState.guessing == 0) {
                namedTableReference.SchemaObject = schemaObject;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 71:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_02b2;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        this.tableHints(namedTableReference, namedTableReference.TableHints, false);
                        goto IL_02b2;
                    case 92:
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 164:
                    case 167:
                    case 169:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02b2;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02b2:
            return namedTableReference;
        }

        public void parenthesizedOptExpressionWithDefaultList(TSqlFragment vParent, IList<ScalarExpression> expressions) {
            IToken token = null;
            this.match(191);
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 47:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    this.expressionWithDefaultList(vParent, expressions);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public void tableHints(TSqlFragment vParent, IList<TableHint> hints, bool indexHintAllowed) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            TableHint item = this.tableHint(indexHintAllowed);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, item);
            }
            while (true) {
                if (!TSql80ParserInternal.tokenSet_58_.member(this.LA(1))) {
                    break;
                }
                switch (this.LA(1)) {
                    case 198:
                        this.match(198);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 78:
                    case 84:
                    case 232:
                        break;
                }
                item = this.tableHint(indexHintAllowed);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, item);
                }
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
        }

        public NamedTableReference schemaObjectTableReference(SchemaObjectName vSchemaObjectName) {
            NamedTableReference namedTableReference = base.FragmentFactory.CreateFragment<NamedTableReference>();
            namedTableReference.SchemaObject = vSchemaObjectName;
            bool flag = false;
            if ((this.LA(1) == 78 || this.LA(1) == 171 || this.LA(1) == 191) && TSql80ParserInternal.tokenSet_59_.member(this.LA(2))) {
                this.nonParameterTableHints(namedTableReference, namedTableReference.TableHints, ref flag);
                int num = this.LA(1);
                if (num <= 106) {
                    switch (num) {
                        case 9:
                            break;
                        default:
                            goto IL_03c9;
                        case 1:
                        case 6:
                        case 12:
                        case 13:
                        case 15:
                        case 17:
                        case 22:
                        case 23:
                        case 28:
                        case 29:
                        case 33:
                        case 35:
                        case 36:
                        case 44:
                        case 45:
                        case 46:
                        case 48:
                        case 49:
                        case 54:
                        case 55:
                        case 56:
                        case 59:
                        case 60:
                        case 61:
                        case 64:
                        case 67:
                        case 72:
                        case 74:
                        case 75:
                        case 76:
                        case 77:
                        case 82:
                        case 85:
                        case 86:
                        case 87:
                        case 90:
                        case 92:
                        case 93:
                        case 95:
                        case 105:
                        case 106:
                            goto IL_066d;
                    }
                } else {
                    switch (num) {
                        case 232:
                        case 233:
                            break;
                        default:
                            goto IL_03c9;
                        case 111:
                        case 113:
                        case 114:
                        case 119:
                        case 123:
                        case 125:
                        case 126:
                        case 129:
                        case 131:
                        case 132:
                        case 133:
                        case 134:
                        case 138:
                        case 140:
                        case 142:
                        case 143:
                        case 144:
                        case 156:
                        case 158:
                        case 160:
                        case 161:
                        case 162:
                        case 167:
                        case 169:
                        case 170:
                        case 171:
                        case 172:
                        case 173:
                        case 176:
                        case 180:
                        case 181:
                        case 191:
                        case 192:
                        case 194:
                        case 198:
                        case 204:
                        case 219:
                        case 220:
                            goto IL_066d;
                    }
                }
                this.simpleTableReferenceAlias(namedTableReference);
                if (base.inputState.guessing == 0 && namedTableReference.Alias != null && flag) {
                    TSql80ParserBaseInternal.ThrowIncorrectSyntaxErrorException(namedTableReference.Alias);
                }
                goto IL_066d;
            }
            if (this.LA(1) != 9 && this.LA(1) != 232 && this.LA(1) != 233) {
                if (TSql80ParserInternal.tokenSet_32_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                    goto IL_066d;
                }
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            this.simpleTableReferenceAlias(namedTableReference);
            bool flag2 = false;
            if (this.LA(1) == 191 && this.LA(2) == 221) {
                int pos = this.mark();
                flag2 = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.integer();
                } catch (RecognitionException) {
                    flag2 = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag2) {
                IndexTableHint item = this.oldForceIndex();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(namedTableReference, namedTableReference.TableHints, item);
                }
                goto IL_066d;
            }
            bool flag3 = false;
            if ((this.LA(1) == 78 || this.LA(1) == 171 || this.LA(1) == 191) && TSql80ParserInternal.tokenSet_60_.member(this.LA(2))) {
                int pos2 = this.mark();
                flag3 = true;
                base.inputState.guessing++;
                try {
                    switch (this.LA(1)) {
                        case 171:
                            this.match(171);
                            break;
                        case 78:
                            this.match(78);
                            break;
                        case 191:
                            this.match(191);
                            switch (this.LA(1)) {
                                case 78:
                                    this.match(78);
                                    break;
                                case 84:
                                    this.match(84);
                                    break;
                                case 232:
                                case 233:
                                    this.identifier();
                                    break;
                                default:
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                } catch (RecognitionException) {
                    flag3 = false;
                }
                this.rewind(pos2);
                base.inputState.guessing--;
            }
            if (flag3) {
                this.nonParameterTableHints(namedTableReference, namedTableReference.TableHints, ref flag);
                goto IL_066d;
            }
            if (TSql80ParserInternal.tokenSet_32_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                goto IL_066d;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_03c9:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_066d:
            return namedTableReference;
        }

        public SchemaObjectFunctionTableReference schemaObjectFunctionTableReference(SchemaObjectName vSchemaObjectName) {
            SchemaObjectFunctionTableReference schemaObjectFunctionTableReference = base.FragmentFactory.CreateFragment<SchemaObjectFunctionTableReference>();
            schemaObjectFunctionTableReference.SchemaObject = vSchemaObjectName;
            this.parenthesizedOptExpressionWithDefaultList(schemaObjectFunctionTableReference, schemaObjectFunctionTableReference.Parameters);
            this.simpleTableReferenceAliasOpt(schemaObjectFunctionTableReference);
            if (this.LA(1) == 191 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                this.columnNameList(schemaObjectFunctionTableReference, schemaObjectFunctionTableReference.Columns);
                goto IL_0099;
            }
            if (TSql80ParserInternal.tokenSet_32_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                goto IL_0099;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0099:
            return schemaObjectFunctionTableReference;
        }

        public void nonParameterTableHints(TSqlFragment vParent, IList<TableHint> hints, ref bool withSpecified) {
            IToken token = null;
            switch (this.LA(1)) {
                case 78: {
                        token = this.LT(1);
                        this.match(78);
                        if (base.inputState.guessing == 0) {
                            TableHint tableHint = base.FragmentFactory.CreateFragment<TableHint>();
                            TSql80ParserBaseInternal.UpdateTokenInfo(tableHint, token);
                            tableHint.HintKind = TableHintKind.HoldLock;
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, tableHint);
                        }
                        bool flag = false;
                        if (this.LA(1) == 191 && this.LA(2) == 221) {
                            int pos = this.mark();
                            flag = true;
                            base.inputState.guessing++;
                            try {
                                this.match(191);
                                this.integer();
                            } catch (RecognitionException) {
                                flag = false;
                            }
                            this.rewind(pos);
                            base.inputState.guessing--;
                        }
                        if (flag) {
                            IndexTableHint item = this.oldForceIndex();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, item);
                            }
                            break;
                        }
                        bool flag2 = false;
                        if ((this.LA(1) == 171 || this.LA(1) == 191) && TSql80ParserInternal.tokenSet_61_.member(this.LA(2))) {
                            int pos2 = this.mark();
                            flag2 = true;
                            base.inputState.guessing++;
                            try {
                                this.match(191);
                                switch (this.LA(1)) {
                                    case 232:
                                    case 233:
                                        this.identifier();
                                        break;
                                    case 84:
                                        this.match(84);
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                            } catch (RecognitionException) {
                                flag2 = false;
                            }
                            this.rewind(pos2);
                            base.inputState.guessing--;
                        }
                        if (flag2) {
                            this.simpleTableHints(vParent, hints, ref withSpecified);
                            break;
                        }
                        if (TSql80ParserInternal.tokenSet_62_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                            break;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 171:
                case 191:
                    this.simpleTableHints(vParent, hints, ref withSpecified);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public IndexTableHint oldForceIndex() {
            IndexTableHint indexTableHint = base.FragmentFactory.CreateFragment<IndexTableHint>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            Literal valueExpression = this.integer();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(indexTableHint, token);
                indexTableHint.HintKind = TableHintKind.Index;
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(indexTableHint, indexTableHint.IndexValues, base.IdentifierOrValueExpression(valueExpression));
                TSql80ParserBaseInternal.UpdateTokenInfo(indexTableHint, token2);
            }
            return indexTableHint;
        }

        public void fullTextTable(FullTextTableReference vParent) {
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 32:
                    token = this.LT(1);
                    this.match(32);
                    if (base.inputState.guessing == 0) {
                        vParent.FullTextFunctionType = FullTextFunctionType.Contains;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                case 70:
                    token2 = this.LT(1);
                    this.match(70);
                    if (base.inputState.guessing == 0) {
                        vParent.FullTextFunctionType = FullTextFunctionType.FreeText;
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void fulltextTableColumnList(FullTextTableReference vParent) {
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        ColumnReferenceExpression item = this.identifierColumnReferenceExpression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Columns, item);
                        }
                        break;
                    }
                case 195: {
                        ColumnReferenceExpression item = this.starColumnReferenceExpression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Columns, item);
                        }
                        break;
                    }
                default:
                    if (this.LA(1) == 191 && this.LA(2) == 195) {
                        this.match(191);
                        ColumnReferenceExpression item = this.starColumnReferenceExpression();
                        this.match(192);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Columns, item);
                        }
                        break;
                    }
                    if (this.LA(1) == 191 && (this.LA(2) == 200 || this.LA(2) == 232 || this.LA(2) == 233)) {
                        this.match(191);
                        ColumnReferenceExpression item = this.identifierColumnReferenceExpression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Columns, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.identifierColumnReferenceExpression();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Columns, item);
                            }
                        }
                        this.match(192);
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void fulltextTableOptions(FullTextTableReference vParent) {
            if (this.LA(1) == 198 && this.LA(2) == 232) {
                this.match(198);
                ValueExpression language = this.languageExpression();
                if (base.inputState.guessing == 0) {
                    vParent.Language = language;
                }
                switch (this.LA(1)) {
                    case 192:
                        break;
                    case 198: {
                            this.match(198);
                            ValueExpression topN = this.unsignedInteger();
                            if (base.inputState.guessing == 0) {
                                vParent.TopN = topN;
                            }
                            break;
                        }
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                return;
            }
            if (this.LA(1) == 198 && (this.LA(2) == 221 || this.LA(2) == 234)) {
                this.match(198);
                ValueExpression topN = this.unsignedInteger();
                if (base.inputState.guessing == 0) {
                    vParent.TopN = topN;
                }
                switch (this.LA(1)) {
                    case 192:
                        break;
                    case 198: {
                            this.match(198);
                            ValueExpression language = this.languageExpression();
                            if (base.inputState.guessing == 0) {
                                vParent.Language = language;
                            }
                            break;
                        }
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ColumnReferenceExpression identifierColumnReferenceExpression() {
            ColumnReferenceExpression columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            MultiPartIdentifier multiPartIdentifier = this.multiPartIdentifier(1);
            if (base.inputState.guessing == 0) {
                columnReferenceExpression.ColumnType = ColumnType.Regular;
                columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
            }
            return columnReferenceExpression;
        }

        public ColumnReferenceExpression starColumnReferenceExpression() {
            ColumnReferenceExpression columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            IToken token = null;
            token = this.LT(1);
            this.match(195);
            if (base.inputState.guessing == 0) {
                columnReferenceExpression.ColumnType = ColumnType.Wildcard;
                TSql80ParserBaseInternal.UpdateTokenInfo(columnReferenceExpression, token);
            }
            return columnReferenceExpression;
        }

        public ValueExpression languageExpression() {
            ValueExpression result = null;
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "LANGUAGE");
            }
            ValueExpression valueExpression = this.binaryOrIntegerOrStringOrVariable();
            if (base.inputState.guessing == 0) {
                result = valueExpression;
            }
            return result;
        }

        public ValueExpression unsignedInteger() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ValueExpression binaryOrIntegerOrStringOrVariable() {
            switch (this.LA(1)) {
                case 224:
                    return this.binary();
                case 230:
                case 231:
                    return this.stringLiteral();
                case 221:
                    return this.integer();
                case 234:
                    return this.variable();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public OpenXmlTableReference openXmlParams() {
            OpenXmlTableReference openXmlTableReference = base.FragmentFactory.CreateFragment<OpenXmlTableReference>();
            VariableReference variable = this.variable();
            this.match(198);
            ValueExpression rowPattern = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                openXmlTableReference.Variable = variable;
                openXmlTableReference.RowPattern = rowPattern;
            }
            switch (this.LA(1)) {
                case 198: {
                        this.match(198);
                        ValueExpression flags = this.unsignedInteger();
                        if (base.inputState.guessing == 0) {
                            openXmlTableReference.Flags = flags;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            return openXmlTableReference;
        }

        public void openXmlWithClauseOpt(OpenXmlTableReference vParent) {
            IToken token = null;
            bool flag = false;
            if (this.LA(1) == 171 && TSql80ParserInternal.tokenSet_56_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(171);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                if (this.LA(1) == 171 && this.LA(2) == 191) {
                    this.match(171);
                    this.match(191);
                    this.openXmlSchemaItemList(vParent);
                    token = this.LT(1);
                    this.match(192);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    return;
                }
                if (this.LA(1) == 171 && (this.LA(2) == 200 || this.LA(2) == 232 || this.LA(2) == 233)) {
                    this.match(171);
                    SchemaObjectName tableName = this.schemaObjectThreePartName();
                    if (base.inputState.guessing == 0) {
                        vParent.TableName = tableName;
                    }
                    return;
                }
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (TSql80ParserInternal.tokenSet_62_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_33_.member(this.LA(2))) {
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void openXmlSchemaItemList(OpenXmlTableReference vParent) {
            SchemaDeclarationItem item = this.openXmlSchemaItem();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.SchemaDeclarationItems, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.openXmlSchemaItem();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.SchemaDeclarationItems, item);
                }
            }
        }

        public SchemaDeclarationItem openXmlSchemaItem() {
            SchemaDeclarationItem schemaDeclarationItem = base.FragmentFactory.CreateFragment<SchemaDeclarationItem>();
            ColumnDefinitionBase columnDefinition = this.columnDefinitionBasic();
            if (base.inputState.guessing == 0) {
                schemaDeclarationItem.ColumnDefinition = columnDefinition;
            }
            switch (this.LA(1)) {
                case 230:
                case 231:
                case 234: {
                        ValueExpression mapping = this.stringOrVariable();
                        if (base.inputState.guessing == 0) {
                            schemaDeclarationItem.Mapping = mapping;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                case 198:
                    break;
            }
            return schemaDeclarationItem;
        }

        public ColumnDefinitionBase columnDefinitionBasic() {
            ColumnDefinitionBase columnDefinitionBase = base.FragmentFactory.CreateFragment<ColumnDefinitionBase>();
            Identifier columnIdentifier = this.identifier();
            DataTypeReference dataType = this.scalarDataType();
            if (base.inputState.guessing == 0) {
                columnDefinitionBase.ColumnIdentifier = columnIdentifier;
                columnDefinitionBase.DataType = dataType;
            }
            this.collationOpt(columnDefinitionBase);
            return columnDefinitionBase;
        }

        public TableReferenceWithAlias openRowsetRowset() {
            IToken token = null;
            token = this.LT(1);
            this.match(109);
            this.match(191);
            TableReferenceWithAlias tableReferenceWithAlias;
            switch (this.LA(1)) {
                case 230:
                case 231:
                    tableReferenceWithAlias = this.openRowsetParams();
                    break;
                case 232:
                case 233:
                    tableReferenceWithAlias = this.internalOpenRowsetArgs();
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tableReferenceWithAlias, token);
            }
            return tableReferenceWithAlias;
        }

        public OpenQueryTableReference openQueryRowset() {
            OpenQueryTableReference openQueryTableReference = base.FragmentFactory.CreateFragment<OpenQueryTableReference>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(108);
            this.match(191);
            Identifier linkedServer = this.identifier();
            this.match(198);
            StringLiteral query = this.stringLiteral();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(openQueryTableReference, token);
                openQueryTableReference.LinkedServer = linkedServer;
                openQueryTableReference.Query = query;
                TSql80ParserBaseInternal.UpdateTokenInfo(openQueryTableReference, token2);
            }
            return openQueryTableReference;
        }

        public AdHocTableReference adhocRowset() {
            AdHocTableReference adHocTableReference = base.FragmentFactory.CreateFragment<AdHocTableReference>();
            AdHocDataSource dataSource = this.adhocDataSource();
            this.match(200);
            if (base.inputState.guessing == 0) {
                adHocTableReference.DataSource = dataSource;
            }
            SchemaObjectNameOrValueExpression @object = this.objectOrString();
            if (base.inputState.guessing == 0) {
                adHocTableReference.Object = @object;
            }
            return adHocTableReference;
        }

        public OpenRowsetTableReference openRowsetParams() {
            OpenRowsetTableReference openRowsetTableReference = base.FragmentFactory.CreateFragment<OpenRowsetTableReference>();
            IToken token = null;
            StringLiteral providerName = this.stringLiteral();
            this.match(198);
            if (base.inputState.guessing == 0) {
                openRowsetTableReference.ProviderName = providerName;
            }
            if ((this.LA(1) == 230 || this.LA(1) == 231) && this.LA(2) == 204) {
                StringLiteral dataSource = this.stringLiteral();
                if (base.inputState.guessing == 0) {
                    openRowsetTableReference.DataSource = dataSource;
                }
                this.match(204);
                switch (this.LA(1)) {
                    case 230:
                    case 231: {
                            StringLiteral userId = this.stringLiteral();
                            if (base.inputState.guessing == 0) {
                                openRowsetTableReference.UserId = userId;
                            }
                            break;
                        }
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 204:
                        break;
                }
                this.match(204);
                switch (this.LA(1)) {
                    case 230:
                    case 231: {
                            StringLiteral password = this.stringLiteral();
                            if (base.inputState.guessing == 0) {
                                openRowsetTableReference.Password = password;
                            }
                            break;
                        }
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 198:
                        break;
                }
                goto IL_01ac;
            }
            if ((this.LA(1) == 230 || this.LA(1) == 231) && this.LA(2) == 198) {
                StringLiteral providerString = this.stringLiteral();
                if (base.inputState.guessing == 0) {
                    openRowsetTableReference.ProviderString = providerString;
                }
                goto IL_01ac;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_01ac:
            this.match(198);
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        SchemaObjectName @object = this.schemaObjectThreePartName();
                        if (base.inputState.guessing == 0) {
                            openRowsetTableReference.Object = @object;
                        }
                        break;
                    }
                case 230:
                case 231: {
                        StringLiteral query = this.stringLiteral();
                        if (base.inputState.guessing == 0) {
                            openRowsetTableReference.Query = query;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(openRowsetTableReference, token);
            }
            this.simpleTableReferenceAliasOpt(openRowsetTableReference);
            return openRowsetTableReference;
        }

        public InternalOpenRowset internalOpenRowsetArgs() {
            InternalOpenRowset internalOpenRowset = base.FragmentFactory.CreateFragment<InternalOpenRowset>();
            IToken token = null;
            Identifier identifier = this.identifier();
            if (base.inputState.guessing == 0) {
                internalOpenRowset.Identifier = identifier;
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                ScalarExpression item = this.possibleNegativeConstant();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(internalOpenRowset, internalOpenRowset.VarArgs, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(internalOpenRowset, token);
            }
            this.simpleTableReferenceAliasOpt(internalOpenRowset);
            return internalOpenRowset;
        }

        public AdHocDataSource adhocDataSource() {
            AdHocDataSource adHocDataSource = base.FragmentFactory.CreateFragment<AdHocDataSource>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(107);
            this.match(191);
            StringLiteral providerName = this.stringLiteral();
            this.match(198);
            StringLiteral initString = this.stringLiteral();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(adHocDataSource, token);
                adHocDataSource.ProviderName = providerName;
                adHocDataSource.InitString = initString;
                TSql80ParserBaseInternal.UpdateTokenInfo(adHocDataSource, token2);
            }
            return adHocDataSource;
        }

        public SchemaObjectNameOrValueExpression objectOrString() {
            SchemaObjectNameOrValueExpression schemaObjectNameOrValueExpression = base.FragmentFactory.CreateFragment<SchemaObjectNameOrValueExpression>();
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        SchemaObjectName schemaObjectName = this.schemaObjectThreePartName();
                        if (base.inputState.guessing == 0) {
                            schemaObjectNameOrValueExpression.SchemaObjectName = schemaObjectName;
                        }
                        break;
                    }
                case 230:
                case 231: {
                        Literal valueExpression = this.stringLiteral();
                        if (base.inputState.guessing == 0) {
                            schemaObjectNameOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return schemaObjectNameOrValueExpression;
        }

        public void simpleTableHints(TSqlFragment vParent, IList<TableHint> hints, ref bool withSpecified) {
            IToken token = null;
            switch (this.LA(1)) {
                case 171:
                    token = this.LT(1);
                    this.match(171);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                        withSpecified = true;
                    }
                    if (this.LA(1) == 191 && this.LA(2) == 221) {
                        IndexTableHint item = this.oldForceIndex();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, item);
                        }
                        break;
                    }
                    if (this.LA(1) == 191 && (this.LA(2) == 78 || this.LA(2) == 84 || this.LA(2) == 232)) {
                        this.tableHints(vParent, hints, true);
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 191:
                    this.tableHints(vParent, hints, true);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TableHint tableHint(bool indexHintAllowed) {
            switch (this.LA(1)) {
                case 78:
                case 232:
                    return this.simpleTableHint();
                case 84:
                    return this.indexTableHint(indexHintAllowed);
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TableHint simpleTableHint() {
            TableHint tableHint = base.FragmentFactory.CreateFragment<TableHint>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 78:
                    token = this.LT(1);
                    this.match(78);
                    if (base.inputState.guessing == 0) {
                        tableHint.HintKind = TableHintKind.HoldLock;
                        TSql80ParserBaseInternal.UpdateTokenInfo(tableHint, token);
                    }
                    break;
                case 232:
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        tableHint.HintKind = TableHintOptionsHelper.Instance.ParseOption(token2, SqlVersionFlags.TSql80);
                        TSql80ParserBaseInternal.UpdateTokenInfo(tableHint, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return tableHint;
        }

        public IndexTableHint indexTableHint(bool indexHintAllowed) {
            IndexTableHint indexTableHint = base.FragmentFactory.CreateFragment<IndexTableHint>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(84);
            if (base.inputState.guessing == 0) {
                if (!indexHintAllowed) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46074", token, TSqlParserResource.SQL46074Message);
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(indexTableHint, token);
                indexTableHint.HintKind = TableHintKind.Index;
            }
            switch (this.LA(1)) {
                case 206: {
                        this.match(206);
                        IdentifierOrValueExpression item = this.identifierOrInteger();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(indexTableHint, indexTableHint.IndexValues, item);
                        }
                        break;
                    }
                case 191: {
                        this.match(191);
                        IdentifierOrValueExpression item = this.identifierOrInteger();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(indexTableHint, indexTableHint.IndexValues, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.identifierOrInteger();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(indexTableHint, indexTableHint.IndexValues, item);
                            }
                        }
                        token2 = this.LT(1);
                        this.match(192);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(indexTableHint, token2);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return indexTableHint;
        }

        public IdentifierOrValueExpression identifierOrInteger() {
            IdentifierOrValueExpression identifierOrValueExpression = base.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            switch (this.LA(1)) {
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.Identifier = identifier;
                        }
                        break;
                    }
                case 221: {
                        Literal valueExpression = this.integer();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierOrValueExpression;
        }

        public void singleOldStyleTableHint(TSqlFragment vParent, IList<TableHint> hints) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
            TableHint item = this.tableHint(true);
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, hints, item);
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
        }

        public WhereClause whereCurrentOfCursorClause() {
            WhereClause whereClause = base.FragmentFactory.CreateFragment<WhereClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(169);
            this.match(37);
            this.match(102);
            CursorId cursor = this.cursorId();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(whereClause, token);
                whereClause.Cursor = cursor;
            }
            return whereClause;
        }

        public ExpressionGroupingSpecification simpleGroupByItem() {
            ExpressionGroupingSpecification expressionGroupingSpecification = base.FragmentFactory.CreateFragment<ExpressionGroupingSpecification>();
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                expressionGroupingSpecification.Expression = expression;
            }
            return expressionGroupingSpecification;
        }

        public ExpressionWithSortOrder expressionWithSortOrder() {
            ExpressionWithSortOrder expressionWithSortOrder = base.FragmentFactory.CreateFragment<ExpressionWithSortOrder>();
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                expressionWithSortOrder.Expression = expression;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 10:
                    case 50: {
                            SortOrder sortOrder = this.orderByOption(expressionWithSortOrder);
                            if (base.inputState.guessing == 0) {
                                expressionWithSortOrder.SortOrder = sortOrder;
                            }
                            goto IL_02ec;
                        }
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 87:
                    case 92:
                        goto IL_02ec;
                }
            } else {
                switch (num) {
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_02ec;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02ec:
            return expressionWithSortOrder;
        }

        public ComputeFunction computeFunction() {
            ComputeFunction computeFunction = base.FragmentFactory.CreateFragment<ComputeFunction>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                computeFunction.ComputeFunctionType = ComputeFunctionTypeHelper.Instance.ParseOption(token);
            }
            this.match(191);
            ScalarExpression expression = this.expression();
            if (base.inputState.guessing == 0) {
                computeFunction.Expression = expression;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(computeFunction, token2);
            }
            return computeFunction;
        }

        public SortOrder orderByOption(TSqlFragment vParent) {
            SortOrder result = SortOrder.NotSpecified;
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 10:
                    token = this.LT(1);
                    this.match(10);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                        result = SortOrder.Ascending;
                    }
                    break;
                case 50:
                    token2 = this.LT(1);
                    this.match(50);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                        result = SortOrder.Descending;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public XmlForClause xmlForClause() {
            XmlForClause xmlForClause = base.FragmentFactory.CreateFragment<XmlForClause>();
            IToken token = null;
            XmlForClauseOptions xmlForClauseOptions = XmlForClauseOptions.None;
            token = this.LT(1);
            this.match(232);
            XmlForClauseOption item = this.xmlForClauseMode();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "XML");
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(xmlForClause, xmlForClause.Options, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.xmlParam(xmlForClauseOptions);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(xmlForClause, xmlForClause.Options, item);
                    xmlForClauseOptions |= item.OptionKind;
                }
            }
            return xmlForClause;
        }

        public UpdateForClause updateForClause() {
            UpdateForClause updateForClause = base.FragmentFactory.CreateFragment<UpdateForClause>();
            IToken token = null;
            token = this.LT(1);
            this.match(160);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(updateForClause, token);
            }
            int num = this.LA(1);
            if (num <= 95) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                    case 95:
                        goto IL_030e;
                }
            } else {
                switch (num) {
                    case 102: {
                            this.match(102);
                            ColumnReferenceExpression item = this.column();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(updateForClause, updateForClause.Columns, item);
                            }
                            while (true) {
                                if (this.LA(1) != 198) {
                                    break;
                                }
                                this.match(198);
                                item = this.column();
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(updateForClause, updateForClause.Columns, item);
                                }
                            }
                            goto IL_030e;
                        }
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_030e;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_030e:
            return updateForClause;
        }

        public XmlForClauseOption xmlForClauseMode() {
            XmlForClauseOption xmlForClauseOption = base.FragmentFactory.CreateFragment<XmlForClauseOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                xmlForClauseOption.OptionKind = XmlForClauseModeHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(xmlForClauseOption, token);
            }
            if (this.LA(1) == 191 && (this.LA(2) == 230 || this.LA(2) == 231)) {
                token2 = this.LT(1);
                this.match(191);
                Literal value = this.stringLiteral();
                token3 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    if (xmlForClauseOption.OptionKind == XmlForClauseOptions.Explicit || xmlForClauseOption.OptionKind == XmlForClauseOptions.Auto) {
                        throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token2);
                    }
                    xmlForClauseOption.Value = value;
                    TSql80ParserBaseInternal.UpdateTokenInfo(xmlForClauseOption, token3);
                }
                goto IL_0115;
            }
            if (TSql80ParserInternal.tokenSet_63_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_0115;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0115:
            return xmlForClauseOption;
        }

        public XmlForClauseOption xmlParam(XmlForClauseOptions encountered) {
            XmlForClauseOption xmlForClauseOption = base.FragmentFactory.CreateFragment<XmlForClauseOption>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            token = this.LT(1);
            this.match(232);
            if (this.LA(1) == 191 && (this.LA(2) == 230 || this.LA(2) == 231)) {
                token2 = this.LT(1);
                this.match(191);
                Literal value = this.stringLiteral();
                token3 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    if (!TSql80ParserBaseInternal.TryMatch(token, "XMLSCHEMA") && !TSql80ParserBaseInternal.TryMatch(token, "ROOT")) {
                        throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token2);
                    }
                    xmlForClauseOption.Value = value;
                    TSql80ParserBaseInternal.UpdateTokenInfo(xmlForClauseOption, token3);
                }
                goto IL_01a3;
            }
            if (this.LA(1) == 232) {
                token4 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    if (TSql80ParserBaseInternal.TryMatch(token, "BINARY")) {
                        TSql80ParserBaseInternal.Match(token4, "BASE64");
                        xmlForClauseOption.OptionKind = XmlForClauseOptions.BinaryBase64;
                    } else {
                        TSql80ParserBaseInternal.Match(token, "ELEMENTS");
                        if (TSql80ParserBaseInternal.TryMatch(token4, "XSINIL")) {
                            xmlForClauseOption.OptionKind = XmlForClauseOptions.ElementsXsiNil;
                        } else {
                            TSql80ParserBaseInternal.Match(token4, "ABSENT");
                            xmlForClauseOption.OptionKind = XmlForClauseOptions.ElementsAbsent;
                        }
                    }
                    TSql80ParserBaseInternal.UpdateTokenInfo(xmlForClauseOption, token4);
                }
                goto IL_01a3;
            }
            if (TSql80ParserInternal.tokenSet_63_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_11_.member(this.LA(2))) {
                goto IL_01a3;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_01a3:
            if (base.inputState.guessing == 0) {
                if (xmlForClauseOption.OptionKind == XmlForClauseOptions.None) {
                    xmlForClauseOption.OptionKind = XmlForClauseOptionsHelper.Instance.ParseOption(token);
                    TSql80ParserBaseInternal.UpdateTokenInfo(xmlForClauseOption, token);
                }
                TSql80ParserBaseInternal.CheckXmlForClauseOptionDuplication(encountered, xmlForClauseOption.OptionKind, token);
            }
            return xmlForClauseOption;
        }

        public OptimizerHint hint() {
            if ((this.LA(1) == 113 || this.LA(1) == 232) && TSql80ParserInternal.tokenSet_64_.member(this.LA(2))) {
                return this.simpleOptimizerHint();
            }
            if (this.LA(1) == 232 && this.LA(2) == 221) {
                return this.literalOptimizerHint();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public OptimizerHint simpleOptimizerHint() {
            OptimizerHint optimizerHint = base.FragmentFactory.CreateFragment<OptimizerHint>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            IToken token6 = null;
            IToken token7 = null;
            if (this.LA(1) == 232 && this.LA(2) == 90) {
                token = this.LT(1);
                this.match(232);
                this.match(90);
                if (base.inputState.guessing == 0) {
                    optimizerHint.HintKind = TSql80ParserBaseInternal.ParseJoinOptimizerHint(token);
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 232 && this.LA(2) == 158) {
                token2 = this.LT(1);
                this.match(232);
                this.match(158);
                if (base.inputState.guessing == 0) {
                    optimizerHint.HintKind = TSql80ParserBaseInternal.ParseUnionOptimizerHint(token2);
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 232 && this.LA(2) == 113) {
                token3 = this.LT(1);
                this.match(232);
                this.match(113);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token3, "FORCE");
                    optimizerHint.HintKind = OptimizerHintKind.ForceOrder;
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 232 && this.LA(2) == 76) {
                token4 = this.LT(1);
                this.match(232);
                this.match(76);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.Match(token4, "HASH");
                    optimizerHint.HintKind = OptimizerHintKind.HashGroup;
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 113) {
                this.LT(1);
                this.match(113);
                this.match(76);
                if (base.inputState.guessing == 0) {
                    optimizerHint.HintKind = OptimizerHintKind.OrderGroup;
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 232 && this.LA(2) == 117) {
                token5 = this.LT(1);
                this.match(232);
                this.match(117);
                if (base.inputState.guessing == 0) {
                    optimizerHint.HintKind = PlanOptimizerHintHelper.Instance.ParseOption(token5, SqlVersionFlags.TSql80);
                }
                goto IL_02d0;
            }
            if (this.LA(1) == 232 && this.LA(2) == 232) {
                token6 = this.LT(1);
                this.match(232);
                token7 = this.LT(1);
                this.match(232);
                if (base.inputState.guessing == 0) {
                    if (TSql80ParserBaseInternal.TryMatch(token6, "EXPAND")) {
                        TSql80ParserBaseInternal.Match(token7, "VIEWS");
                        optimizerHint.HintKind = OptimizerHintKind.ExpandViews;
                    } else {
                        TSql80ParserBaseInternal.Match(token6, "BYPASS");
                        TSql80ParserBaseInternal.Match(token7, "OPTIMIZER_QUEUE");
                        optimizerHint.HintKind = OptimizerHintKind.BypassOptimizerQueue;
                    }
                }
                goto IL_02d0;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02d0:
            return optimizerHint;
        }

        public LiteralOptimizerHint literalOptimizerHint() {
            LiteralOptimizerHint literalOptimizerHint = base.FragmentFactory.CreateFragment<LiteralOptimizerHint>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            Literal value = this.integer();
            if (base.inputState.guessing == 0) {
                literalOptimizerHint.HintKind = IntegerOptimizerHintHelper.Instance.ParseOption(token, SqlVersionFlags.TSql80);
                literalOptimizerHint.Value = value;
            }
            return literalOptimizerHint;
        }

        public void viewStatementBody(ViewStatementBody vResult) {
            IToken token = null;
            IToken token2 = null;
            int num = 0;
            this.match(166);
            SchemaObjectName schemaObjectName = this.schemaObjectTwoPartName();
            if (base.inputState.guessing == 0) {
                vResult.SchemaObjectName = schemaObjectName;
                TSql80ParserBaseInternal.CheckForTemporaryView(schemaObjectName);
                base.ThrowPartialAstIfPhaseOne(vResult);
            }
            switch (this.LA(1)) {
                case 191:
                    this.columnNameList(vResult, vResult.Columns);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 9:
                case 171:
                    break;
            }
            switch (this.LA(1)) {
                case 171: {
                        this.match(171);
                        ViewOption viewOption = this.viewOption();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)viewOption.OptionKind, viewOption);
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.ViewOptions, viewOption);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            viewOption = this.viewOption();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)viewOption.OptionKind, viewOption);
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.ViewOptions, viewOption);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 9:
                    break;
            }
            token = this.LT(1);
            this.match(9);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token);
            }
            SelectStatement selectStatement = this.subqueryExpressionAsStatement();
            if (base.inputState.guessing == 0) {
                vResult.SelectStatement = selectStatement;
            }
            switch (this.LA(1)) {
                case 1:
                case 35:
                case 75:
                case 219:
                    break;
                case 171:
                    this.match(171);
                    this.match(21);
                    token2 = this.LT(1);
                    this.match(111);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token2);
                        vResult.WithCheckOption = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public SchemaObjectName schemaObjectTwoPartName() {
            SchemaObjectName schemaObjectName = base.FragmentFactory.CreateFragment<SchemaObjectName>();
            List<Identifier> otherCollection = this.identifierList(2);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(schemaObjectName, schemaObjectName.Identifiers, otherCollection);
            }
            return schemaObjectName;
        }

        public ViewOption viewOption() {
            ViewOption viewOption = base.FragmentFactory.CreateFragment<ViewOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                viewOption.OptionKind = ViewOptionHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(viewOption, token);
            }
            return viewOption;
        }

        public TriggerOption triggerOption() {
            TriggerOption triggerOption = base.FragmentFactory.CreateFragment<TriggerOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                triggerOption.OptionKind = TriggerOptionHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(triggerOption, token);
            }
            return triggerOption;
        }

        public void procedureOptions(ProcedureStatementBody vParent) {
            int num = 0;
            this.match(171);
            ProcedureOption procedureOption = this.procedureOption();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)procedureOption.OptionKind, procedureOption);
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, procedureOption);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                procedureOption = this.procedureOption();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckOptionDuplication(ref num, (int)procedureOption.OptionKind, procedureOption);
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Options, procedureOption);
                }
            }
        }

        public ProcedureOption procedureOption() {
            ProcedureOption procedureOption = base.FragmentFactory.CreateFragment<ProcedureOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                procedureOption.OptionKind = ProcedureOptionHelper.Instance.ParseOption(token);
                TSql80ParserBaseInternal.UpdateTokenInfo(procedureOption, token);
            }
            return procedureOption;
        }

        public void procedureStatementBody(ProcedureStatementBody vResult, out bool vParseErrorOccurred) {
            IToken token = null;
            vParseErrorOccurred = false;
            try {
                switch (this.LA(1)) {
                    case 120:
                        this.match(120);
                        break;
                    case 121:
                        this.match(121);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                ProcedureReference procedureReference = this.procedureReference();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(procedureReference.Name, "PROCEDURE");
                    vResult.ProcedureReference = procedureReference;
                }
                if (base.inputState.guessing == 0) {
                    base.ThrowPartialAstIfPhaseOne(vResult);
                }
                this.procedureParameterListOptionalParen(vResult);
                switch (this.LA(1)) {
                    case 171:
                        this.procedureOptions(vResult);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 9:
                    case 67:
                        break;
                }
                switch (this.LA(1)) {
                    case 67:
                        this.match(67);
                        this.match(128);
                        if (base.inputState.guessing == 0) {
                            vResult.IsForReplication = true;
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 9:
                        break;
                }
                token = this.LT(1);
                this.match(9);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token);
                }
                int num = this.LA(1);
                if (num <= 86) {
                    switch (num) {
                        case 1:
                            return;
                        case 6:
                        case 12:
                        case 13:
                        case 15:
                        case 17:
                        case 22:
                        case 23:
                        case 28:
                        case 33:
                        case 35:
                        case 44:
                        case 45:
                        case 46:
                        case 48:
                        case 49:
                        case 54:
                        case 60:
                        case 61:
                        case 64:
                        case 74:
                        case 75:
                        case 82:
                        case 86:
                            break;
                        default:
                            goto IL_03a9;
                    }
                } else {
                    switch (num) {
                        case 219:
                            return;
                        case 92:
                        case 95:
                        case 106:
                        case 119:
                        case 123:
                        case 125:
                        case 126:
                        case 129:
                        case 131:
                        case 132:
                        case 134:
                        case 138:
                        case 140:
                        case 142:
                        case 143:
                        case 144:
                        case 156:
                        case 160:
                        case 161:
                        case 162:
                        case 167:
                        case 170:
                        case 172:
                        case 173:
                        case 176:
                        case 180:
                        case 181:
                        case 191:
                        case 220:
                            break;
                        default:
                            goto IL_03a9;
                    }
                }
                StatementList statementList = this.statementList(ref vParseErrorOccurred);
                if (base.inputState.guessing == 0) {
                    vResult.StatementList = statementList;
                }
                goto end_IL_0005;
                IL_03a9:
                throw new NoViableAltException(this.LT(1), this.getFilename());
                end_IL_0005:;
            } catch (NoViableAltException) {
                if (base.inputState.guessing == 0) {
                    if (base.PhaseOne && vResult != null && vResult.ProcedureReference != null && vResult.ProcedureReference.Name != null) {
                        base.ThrowPartialAstIfPhaseOne(vResult);
                        goto end_IL_03be;
                    }
                    throw;
                }
                throw;
                end_IL_03be:;
            }
        }

        public ProcedureReference procedureReference() {
            ProcedureReference procedureReference = base.FragmentFactory.CreateFragment<ProcedureReference>();
            SchemaObjectName name = this.schemaObjectFourPartName();
            Literal number = this.procNumOpt();
            if (base.inputState.guessing == 0) {
                procedureReference.Name = name;
                procedureReference.Number = number;
            }
            return procedureReference;
        }

        public void procedureParameterListOptionalParen(ProcedureStatementBodyBase vResult) {
            IToken token = null;
            switch (this.LA(1)) {
                case 191:
                    this.match(191);
                    this.procedureParameterList(vResult);
                    token = this.LT(1);
                    this.match(192);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token);
                    }
                    break;
                case 9:
                case 67:
                case 171:
                case 234:
                    switch (this.LA(1)) {
                        case 9:
                        case 67:
                        case 171:
                            break;
                        case 234:
                            this.procedureParameterList(vResult);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void procedureParameterList(ProcedureStatementBodyBase vResult) {
            ProcedureParameter item = this.procedureParameter();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Parameters, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.procedureParameter();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Parameters, item);
                }
            }
        }

        public ProcedureParameter procedureParameter() {
            ProcedureParameter procedureParameter = base.FragmentFactory.CreateFragment<ProcedureParameter>();
            Identifier variableName = this.identifierVariable();
            switch (this.LA(1)) {
                case 9:
                    this.match(9);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 42:
                case 53:
                case 96:
                case 232:
                case 233:
                    break;
            }
            if (base.inputState.guessing == 0) {
                procedureParameter.VariableName = variableName;
            }
            switch (this.LA(1)) {
                case 42:
                    this.cursorProcedureParameter(procedureParameter);
                    break;
                case 53:
                case 96:
                case 232:
                case 233:
                    this.scalarProcedureParameter(procedureParameter, true);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return procedureParameter;
        }

        public void cursorProcedureParameter(ProcedureParameter vParent) {
            IToken token = null;
            IToken token2 = null;
            DataTypeReference dataType = this.cursorDataType();
            if (base.inputState.guessing == 0) {
                vParent.DataType = dataType;
            }
            token = this.LT(1);
            this.match(165);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                vParent.IsVarying = true;
            }
            token2 = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token2, "OUTPUT", "OUT");
                vParent.Modifier = ParameterModifier.Output;
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
            }
        }

        public IdentifierLiteral identifierLiteral() {
            IdentifierLiteral identifierLiteral = base.FragmentFactory.CreateFragment<IdentifierLiteral>();
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(identifierLiteral, token);
                        identifierLiteral.SetUnquotedIdentifier(token.getText());
                        TSql80ParserBaseInternal.CheckIdentifierLiteralLength(identifierLiteral);
                    }
                    break;
                case 233:
                    token2 = this.LT(1);
                    this.match(233);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(identifierLiteral, token2);
                        identifierLiteral.SetIdentifier(token2.getText());
                        TSql80ParserBaseInternal.CheckIdentifierLiteralLength(identifierLiteral);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierLiteral;
        }

        public DefaultLiteral defaultLiteral() {
            DefaultLiteral defaultLiteral = base.FragmentFactory.CreateFragment<DefaultLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(47);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(defaultLiteral, token);
                defaultLiteral.Value = token.getText();
            }
            return defaultLiteral;
        }

        public ValueExpression literal() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 223:
                    return this.real();
                case 222:
                    return this.numeric();
                case 225:
                    return this.moneyLiteral();
                case 224:
                    return this.binary();
                case 230:
                case 231:
                    return this.stringLiteral();
                case 100:
                    return this.nullLiteral();
                case 234:
                    return this.globalVariableOrVariableReference();
                case 193:
                    return this.odbcLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public UnaryExpression negativeConstant() {
            UnaryExpression unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
            IToken token = null;
            token = this.LT(1);
            this.match(199);
            Literal expression = this.subroutineParameterLiteral();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token);
                unaryExpression.UnaryExpressionType = UnaryExpressionType.Negative;
                unaryExpression.Expression = expression;
            }
            return unaryExpression;
        }

        public Literal subroutineParameterLiteral() {
            switch (this.LA(1)) {
                case 221:
                    return this.integer();
                case 223:
                    return this.real();
                case 222:
                    return this.numeric();
                case 225:
                    return this.moneyLiteral();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void triggerStatementBody(TriggerStatementBody vResult, out bool vParseErrorOccurred) {
            IToken token = null;
            vParseErrorOccurred = false;
            this.match(155);
            SchemaObjectName name = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckTwoPartNameForSchemaObjectName(name, "TRIGGER");
                vResult.Name = name;
            }
            this.match(105);
            TriggerObject triggerObject = this.triggerObject();
            if (base.inputState.guessing == 0) {
                vResult.TriggerObject = triggerObject;
                base.ThrowPartialAstIfPhaseOne(vResult);
            }
            switch (this.LA(1)) {
                case 171: {
                        this.match(171);
                        TriggerOption item = this.triggerOption();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Options, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.triggerOption();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vResult, vResult.Options, item);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 67:
                case 232:
                    break;
            }
            this.dmlTriggerMidSection(vResult);
            token = this.LT(1);
            this.match(9);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token);
            }
            StatementList statementList = this.statementList(ref vParseErrorOccurred);
            if (base.inputState.guessing == 0) {
                vResult.StatementList = statementList;
            }
        }

        public TriggerObject triggerObject() {
            TriggerObject triggerObject = base.FragmentFactory.CreateFragment<TriggerObject>();
            SchemaObjectName name = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                triggerObject.Name = name;
                triggerObject.TriggerScope = TriggerScope.Normal;
            }
            return triggerObject;
        }

        public void dmlTriggerMidSection(TriggerStatementBody vParent) {
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            switch (this.LA(1)) {
                case 67:
                    this.match(67);
                    if (base.inputState.guessing == 0) {
                        vParent.TriggerType = TriggerType.For;
                    }
                    break;
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    switch (this.LA(1)) {
                        case 102:
                            this.LT(1);
                            this.match(102);
                            if (base.inputState.guessing == 0) {
                                flag = true;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 48:
                        case 86:
                        case 160:
                            break;
                    }
                    if (base.inputState.guessing == 0) {
                        if (flag) {
                            TSql80ParserBaseInternal.Match(token, "INSTEAD");
                            vParent.TriggerType = TriggerType.InsteadOf;
                        } else {
                            TSql80ParserBaseInternal.Match(token, "AFTER");
                            vParent.TriggerType = TriggerType.After;
                        }
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            TriggerAction item = this.dmlTriggerAction();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.TriggerActions, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.dmlTriggerAction();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.TriggerActions, item);
                }
            }
            switch (this.LA(1)) {
                case 171:
                    this.match(171);
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token2, "APPEND");
                        vParent.WithAppend = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 9:
                case 99:
                    break;
            }
            switch (this.LA(1)) {
                case 9:
                    break;
                case 99:
                    this.match(99);
                    this.match(67);
                    this.match(128);
                    if (base.inputState.guessing == 0) {
                        vParent.IsNotForReplication = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public TriggerAction dmlTriggerAction() {
            TriggerAction triggerAction = base.FragmentFactory.CreateFragment<TriggerAction>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            switch (this.LA(1)) {
                case 86:
                    token = this.LT(1);
                    this.match(86);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(triggerAction, token);
                        triggerAction.TriggerActionType = TriggerActionType.Insert;
                    }
                    break;
                case 160:
                    token2 = this.LT(1);
                    this.match(160);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(triggerAction, token2);
                        triggerAction.TriggerActionType = TriggerActionType.Update;
                    }
                    break;
                case 48:
                    token3 = this.LT(1);
                    this.match(48);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(triggerAction, token3);
                        triggerAction.TriggerActionType = TriggerActionType.Delete;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return triggerAction;
        }

        public ExecuteOption executeOption() {
            ExecuteOption executeOption = base.FragmentFactory.CreateFragment<ExecuteOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "RECOMPILE");
                executeOption.OptionKind = ExecuteOptionKind.Recompile;
            }
            return executeOption;
        }

        public void execStart(TSqlFragment vParent) {
            IToken token = null;
            IToken token2 = null;
            switch (this.LA(1)) {
                case 61:
                    token = this.LT(1);
                    this.match(61);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    }
                    break;
                case 60:
                    token2 = this.LT(1);
                    this.match(60);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void execTypes(ExecuteSpecification vParent) {
            IToken token = null;
            if (this.LA(1) == 191) {
                this.match(191);
                ExecutableEntity executableEntity = this.execStrTypes();
                token = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                    vParent.ExecutableEntity = executableEntity;
                }
                return;
            }
            if (TSql80ParserInternal.tokenSet_65_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_66_.member(this.LA(2))) {
                ExecutableEntity executableEntity = this.execProcEx();
                if (base.inputState.guessing == 0) {
                    vParent.ExecutableEntity = executableEntity;
                }
                return;
            }
            if (this.LA(1) == 234 && this.LA(2) == 206) {
                VariableReference variable = this.variable();
                this.match(206);
                ExecutableEntity executableEntity = this.execProcEx();
                if (base.inputState.guessing == 0) {
                    vParent.Variable = variable;
                    vParent.ExecutableEntity = executableEntity;
                }
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ExecutableEntity execStrTypes() {
            ExecutableEntity executableEntity = this.execSqlList();
            switch (this.LA(1)) {
                case 198:
                    this.match(198);
                    this.setParamList(executableEntity);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            return executableEntity;
        }

        public ExecutableProcedureReference execProcEx() {
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233:
                case 234:
                    return this.execProc();
                case 107:
                    return this.adhocDataSourceExecproc();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public ExecutableStringList execSqlList() {
            ExecutableStringList executableStringList = base.FragmentFactory.CreateFragment<ExecutableStringList>();
            ValueExpression item = this.stringOrGlobalVariableOrVariable();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(executableStringList, executableStringList.Strings, item);
            }
            while (true) {
                if (this.LA(1) != 197) {
                    break;
                }
                this.match(197);
                item = this.stringOrGlobalVariableOrVariable();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(executableStringList, executableStringList.Strings, item);
                }
            }
            return executableStringList;
        }

        public void setParamList(ExecutableEntity vParent) {
            bool flag = false;
            int num = 0;
            ExecuteParameter item = this.setParam(ref flag, ref num);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.setParam(ref flag, ref num);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
                }
            }
        }

        public ExecutableProcedureReference adhocDataSourceExecproc() {
            ExecutableProcedureReference executableProcedureReference = base.FragmentFactory.CreateFragment<ExecutableProcedureReference>();
            AdHocDataSource adHocDataSource = this.adhocDataSource();
            this.match(200);
            ProcedureReferenceName procedureReference = this.procObjectReference();
            if (base.inputState.guessing == 0) {
                executableProcedureReference.AdHocDataSource = adHocDataSource;
                executableProcedureReference.ProcedureReference = procedureReference;
            }
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 47:
                        break;
                    default:
                        goto IL_02f7;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_030a;
                }
            } else {
                switch (num) {
                    case 100:
                    case 193:
                    case 199:
                    case 221:
                    case 222:
                    case 223:
                    case 224:
                    case 225:
                    case 230:
                    case 231:
                    case 232:
                    case 233:
                    case 234:
                        break;
                    default:
                        goto IL_02f7;
                    case 95:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_030a;
                }
            }
            this.setParamList(executableProcedureReference);
            goto IL_030a;
            IL_02f7:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_030a:
            return executableProcedureReference;
        }

        public ProcedureReferenceName procObjectReference() {
            ProcedureReferenceName procedureReferenceName = base.FragmentFactory.CreateFragment<ProcedureReferenceName>();
            ProcedureReference procedureReference = this.procedureReference();
            if (base.inputState.guessing == 0) {
                procedureReferenceName.ProcedureReference = procedureReference;
            }
            return procedureReferenceName;
        }

        public ProcedureReferenceName varObjectReference() {
            ProcedureReferenceName procedureReferenceName = base.FragmentFactory.CreateFragment<ProcedureReferenceName>();
            VariableReference procedureVariable = this.variable();
            if (base.inputState.guessing == 0) {
                procedureReferenceName.ProcedureVariable = procedureVariable;
            }
            return procedureReferenceName;
        }

        public Literal procNumOpt() {
            Literal result = null;
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 9:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_02fa;
                }
            } else {
                switch (num) {
                    case 236:
                        this.match(236);
                        result = this.integer();
                        goto IL_02fa;
                    case 95:
                    case 100:
                    case 106:
                    case 111:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 193:
                    case 199:
                    case 204:
                    case 219:
                    case 220:
                    case 221:
                    case 222:
                    case 223:
                    case 224:
                    case 225:
                    case 230:
                    case 231:
                    case 232:
                    case 233:
                    case 234:
                        goto IL_02fa;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_02fa:
            return result;
        }

        public ValueExpression stringOrGlobalVariableOrVariable() {
            ValueExpression valueExpression = null;
            switch (this.LA(1)) {
                case 230:
                case 231:
                    return this.stringLiteral();
                case 234:
                    return this.globalVariableOrVariableReference();
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public RealLiteral real() {
            RealLiteral realLiteral = base.FragmentFactory.CreateFragment<RealLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(223);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(realLiteral, token);
                realLiteral.Value = token.getText();
            }
            return realLiteral;
        }

        public NumericLiteral numeric() {
            NumericLiteral numericLiteral = base.FragmentFactory.CreateFragment<NumericLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(222);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(numericLiteral, token);
                numericLiteral.Value = token.getText();
            }
            return numericLiteral;
        }

        public ExecuteParameter setParam(ref bool nameEqualsValueWasUsed, ref int parameterNumber) {
            ExecuteParameter executeParameter = base.FragmentFactory.CreateFragment<ExecuteParameter>();
            IToken token = null;
            executeParameter.IsOutput = false;
            parameterNumber++;
            if (this.LA(1) == 234 && this.LA(2) == 206) {
                VariableReference variable = this.variable();
                this.match(206);
                if (base.inputState.guessing == 0) {
                    executeParameter.Variable = variable;
                }
                goto IL_0098;
            }
            if (TSql80ParserInternal.tokenSet_67_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_68_.member(this.LA(2))) {
                goto IL_0098;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0098:
            switch (this.LA(1)) {
                case 100:
                case 193:
                case 199:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234: {
                        ScalarExpression scalarExpression = this.possibleNegativeConstantOrIdentifier();
                        if (base.inputState.guessing == 0) {
                            executeParameter.ParameterValue = scalarExpression;
                            if (executeParameter.Variable != null) {
                                nameEqualsValueWasUsed = true;
                            } else if (nameEqualsValueWasUsed) {
                                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46089", scalarExpression, TSqlParserResource.SQL46089Message, parameterNumber.ToString(CultureInfo.CurrentCulture));
                            }
                        }
                        if (this.LA(1) == 232 && (base.NextTokenMatches("OUTPUT") || base.NextTokenMatches("OUT"))) {
                            token = this.LT(1);
                            this.match(232);
                            if (base.inputState.guessing == 0) {
                                VariableReference variableReference = scalarExpression as VariableReference;
                                GlobalVariableExpression globalVariableExpression = scalarExpression as GlobalVariableExpression;
                                if (variableReference == null && globalVariableExpression == null) {
                                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46088", token, TSqlParserResource.SQL46088Message);
                                }
                                TSql80ParserBaseInternal.Match(token, "OUTPUT", "OUT");
                                executeParameter.IsOutput = true;
                                TSql80ParserBaseInternal.UpdateTokenInfo(executeParameter, token);
                            }
                            break;
                        }
                        if (TSql80ParserInternal.tokenSet_69_.member(this.LA(1))) {
                            break;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 47: {
                        Literal parameterValue = this.defaultLiteral();
                        if (base.inputState.guessing == 0) {
                            executeParameter.ParameterValue = parameterValue;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return executeParameter;
        }

        public TableDefinition tableDefinitionCreateTable() {
            TableDefinition tableDefinition = base.FragmentFactory.CreateFragment<TableDefinition>();
            this.tableElement(IndexAffectingStatement.CreateTable, tableDefinition, null);
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                if (!TSql80ParserInternal.tokenSet_70_.member(this.LA(2))) {
                    break;
                }
                this.LT(1);
                this.match(198);
                this.tableElement(IndexAffectingStatement.CreateTable, tableDefinition, null);
            }
            switch (this.LA(1)) {
                case 198:
                    this.match(198);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            return tableDefinition;
        }

        public AlterTableAlterColumnStatement alterTableAlterColumnStatement() {
            AlterTableAlterColumnStatement alterTableAlterColumnStatement = base.FragmentFactory.CreateFragment<AlterTableAlterColumnStatement>();
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            this.match(6);
            this.match(27);
            Identifier columnIdentifier = this.identifier();
            if (base.inputState.guessing == 0) {
                alterTableAlterColumnStatement.ColumnIdentifier = columnIdentifier;
                base.ThrowPartialAstIfPhaseOne(alterTableAlterColumnStatement);
            }
            switch (this.LA(1)) {
                case 53:
                case 96:
                case 232:
                case 233: {
                        DataTypeReference dataType = this.scalarDataType();
                        if (base.inputState.guessing == 0) {
                            alterTableAlterColumnStatement.DataType = dataType;
                        }
                        this.collationOpt(alterTableAlterColumnStatement);
                        int num = this.LA(1);
                        if (num <= 92) {
                            switch (num) {
                                case 1:
                                case 6:
                                case 12:
                                case 13:
                                case 15:
                                case 17:
                                case 22:
                                case 23:
                                case 28:
                                case 33:
                                case 35:
                                case 44:
                                case 45:
                                case 46:
                                case 48:
                                case 49:
                                case 54:
                                case 55:
                                case 56:
                                case 60:
                                case 61:
                                case 64:
                                case 74:
                                case 75:
                                case 82:
                                case 86:
                                case 92:
                                    goto end_IL_0000;
                            }
                        } else {
                            switch (num) {
                                case 99:
                                case 100: {
                                        bool flag2 = this.nullNotNull(alterTableAlterColumnStatement);
                                        if (base.inputState.guessing == 0) {
                                            alterTableAlterColumnStatement.AlterTableAlterColumnOption = (AlterTableAlterColumnOption)(flag2 ? 3 : 4);
                                        }
                                        goto end_IL_0000;
                                    }
                                case 95:
                                case 106:
                                case 119:
                                case 123:
                                case 125:
                                case 126:
                                case 129:
                                case 131:
                                case 132:
                                case 134:
                                case 138:
                                case 140:
                                case 142:
                                case 143:
                                case 144:
                                case 156:
                                case 160:
                                case 161:
                                case 162:
                                case 167:
                                case 170:
                                case 172:
                                case 173:
                                case 176:
                                case 180:
                                case 181:
                                case 191:
                                case 204:
                                case 219:
                                case 220:
                                    goto end_IL_0000;
                            }
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                case 4:
                case 54:
                    switch (this.LA(1)) {
                        case 4:
                            this.match(4);
                            if (base.inputState.guessing == 0) {
                                flag = true;
                            }
                            break;
                        case 54:
                            this.match(54);
                            if (base.inputState.guessing == 0) {
                                flag = false;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    switch (this.LA(1)) {
                        case 136:
                            token = this.LT(1);
                            this.match(136);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(alterTableAlterColumnStatement, token);
                                if (flag) {
                                    alterTableAlterColumnStatement.AlterTableAlterColumnOption = AlterTableAlterColumnOption.AddRowGuidCol;
                                } else {
                                    alterTableAlterColumnStatement.AlterTableAlterColumnOption = AlterTableAlterColumnOption.DropRowGuidCol;
                                }
                            }
                            break;
                        case 99:
                            this.match(99);
                            this.match(67);
                            token2 = this.LT(1);
                            this.match(128);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(alterTableAlterColumnStatement, token2);
                                if (flag) {
                                    alterTableAlterColumnStatement.AlterTableAlterColumnOption = AlterTableAlterColumnOption.AddNotForReplication;
                                } else {
                                    alterTableAlterColumnStatement.AlterTableAlterColumnOption = AlterTableAlterColumnOption.DropNotForReplication;
                                }
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default: {
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    end_IL_0000:
                    break;
            }
            return alterTableAlterColumnStatement;
        }

        public AlterTableTriggerModificationStatement alterTableTriggerModificationStatement() {
            AlterTableTriggerModificationStatement alterTableTriggerModificationStatement = base.FragmentFactory.CreateFragment<AlterTableTriggerModificationStatement>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                alterTableTriggerModificationStatement.TriggerEnforcement = TSql80ParserBaseInternal.ParseTriggerEnforcement(token);
            }
            this.match(155);
            switch (this.LA(1)) {
                case 5:
                    token2 = this.LT(1);
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        alterTableTriggerModificationStatement.All = true;
                        TSql80ParserBaseInternal.UpdateTokenInfo(alterTableTriggerModificationStatement, token2);
                    }
                    break;
                case 232:
                case 233: {
                        Identifier item = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableTriggerModificationStatement, alterTableTriggerModificationStatement.TriggerNames, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.identifier();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableTriggerModificationStatement, alterTableTriggerModificationStatement.TriggerNames, item);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(alterTableTriggerModificationStatement);
            }
            return alterTableTriggerModificationStatement;
        }

        public AlterTableDropTableElementStatement alterTableDropTableElementStatement() {
            AlterTableDropTableElementStatement alterTableDropTableElementStatement = base.FragmentFactory.CreateFragment<AlterTableDropTableElementStatement>();
            this.match(54);
            AlterTableDropTableElement item = this.alterTableDropTableElement();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableDropTableElementStatement, alterTableDropTableElementStatement.AlterTableDropTableElements, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.alterTableDropTableElement();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableDropTableElementStatement, alterTableDropTableElementStatement.AlterTableDropTableElements, item);
                }
            }
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(alterTableDropTableElementStatement);
            }
            return alterTableDropTableElementStatement;
        }

        public ConstraintEnforcement constraintEnforcement() {
            ConstraintEnforcement result = ConstraintEnforcement.NotSpecified;
            switch (this.LA(1)) {
                case 21:
                    this.match(21);
                    if (base.inputState.guessing == 0) {
                        result = ConstraintEnforcement.Check;
                    }
                    break;
                case 97:
                    this.match(97);
                    if (base.inputState.guessing == 0) {
                        result = ConstraintEnforcement.NoCheck;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public AlterTableAddTableElementStatement alterTableAddTableElementStatement(ConstraintEnforcement vExistingRowsCheck) {
            AlterTableAddTableElementStatement alterTableAddTableElementStatement = base.FragmentFactory.CreateFragment<AlterTableAddTableElementStatement>();
            alterTableAddTableElementStatement.ExistingRowsCheckEnforcement = vExistingRowsCheck;
            this.match(4);
            TableDefinition definition = this.tableDefinition(IndexAffectingStatement.AlterTableAddElement, alterTableAddTableElementStatement);
            if (base.inputState.guessing == 0) {
                alterTableAddTableElementStatement.Definition = definition;
            }
            return alterTableAddTableElementStatement;
        }

        public AlterTableConstraintModificationStatement alterTableConstraintModificationStatement(ConstraintEnforcement vExistingRowsCheck) {
            AlterTableConstraintModificationStatement alterTableConstraintModificationStatement = base.FragmentFactory.CreateFragment<AlterTableConstraintModificationStatement>();
            IToken token = null;
            alterTableConstraintModificationStatement.ExistingRowsCheckEnforcement = vExistingRowsCheck;
            ConstraintEnforcement constraintEnforcement = this.constraintEnforcement();
            this.match(30);
            if (base.inputState.guessing == 0) {
                alterTableConstraintModificationStatement.ConstraintEnforcement = constraintEnforcement;
            }
            switch (this.LA(1)) {
                case 5:
                    token = this.LT(1);
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        alterTableConstraintModificationStatement.All = true;
                        TSql80ParserBaseInternal.UpdateTokenInfo(alterTableConstraintModificationStatement, token);
                    }
                    break;
                case 232:
                case 233: {
                        Identifier item = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableConstraintModificationStatement, alterTableConstraintModificationStatement.ConstraintNames, item);
                        }
                        while (true) {
                            if (this.LA(1) != 198) {
                                break;
                            }
                            this.match(198);
                            item = this.identifier();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(alterTableConstraintModificationStatement, alterTableConstraintModificationStatement.ConstraintNames, item);
                            }
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                base.ThrowPartialAstIfPhaseOne(alterTableConstraintModificationStatement);
            }
            return alterTableConstraintModificationStatement;
        }

        public AlterTableDropTableElement alterTableDropTableElement() {
            AlterTableDropTableElement alterTableDropTableElement = base.FragmentFactory.CreateFragment<AlterTableDropTableElement>();
            switch (this.LA(1)) {
                case 30:
                case 232:
                case 233: {
                        switch (this.LA(1)) {
                            case 30:
                                this.match(30);
                                if (base.inputState.guessing == 0) {
                                    alterTableDropTableElement.TableElementType = TableElementType.Constraint;
                                }
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                            case 232:
                            case 233:
                                break;
                        }
                        Identifier name = this.identifier();
                        if (base.inputState.guessing == 0) {
                            alterTableDropTableElement.Name = name;
                        }
                        break;
                    }
                case 27: {
                        this.match(27);
                        Identifier name = this.identifier();
                        if (base.inputState.guessing == 0) {
                            alterTableDropTableElement.TableElementType = TableElementType.Column;
                            alterTableDropTableElement.Name = name;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return alterTableDropTableElement;
        }

        public ColumnDefinition columnDefinition(IndexAffectingStatement statementType, AlterTableAddTableElementStatement vStatement) {
            ColumnDefinition columnDefinition = base.FragmentFactory.CreateFragment<ColumnDefinition>();
            IToken token = null;
            Identifier identifier = null;
            Identifier columnIdentifier = this.identifier();
            if (base.inputState.guessing == 0) {
                columnDefinition.ColumnIdentifier = columnIdentifier;
                if (base.PhaseOne && vStatement != null) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vStatement, vStatement.Definition.ColumnDefinitions, columnDefinition);
                    base.ThrowPartialAstIfPhaseOne(vStatement);
                }
            }
            int num = this.LA(1);
            if (num <= 100) {
                switch (num) {
                    case 9:
                        break;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                    case 92:
                    case 95:
                    case 96:
                    case 99:
                    case 100:
                        goto IL_06c7;
                    default:
                        goto IL_06d8;
                }
                this.match(9);
                ScalarExpression computedColumnExpression = this.expressionWithFlags(ExpressionFlags.ScalarSubqueriesDisallowed);
                if (base.inputState.guessing == 0) {
                    columnDefinition.ComputedColumnExpression = computedColumnExpression;
                }
                int num2 = this.LA(1);
                if (num2 <= 92) {
                    switch (num2) {
                        case 30:
                            break;
                        default:
                            goto IL_06b4;
                        case 1:
                        case 6:
                        case 12:
                        case 13:
                        case 15:
                        case 17:
                        case 22:
                        case 23:
                        case 28:
                        case 33:
                        case 35:
                        case 44:
                        case 45:
                        case 46:
                        case 48:
                        case 49:
                        case 54:
                        case 55:
                        case 56:
                        case 60:
                        case 61:
                        case 64:
                        case 74:
                        case 75:
                        case 82:
                        case 86:
                        case 92:
                            goto IL_06eb;
                    }
                } else {
                    switch (num2) {
                        case 118:
                        case 159:
                            break;
                        default:
                            goto IL_06b4;
                        case 95:
                        case 106:
                        case 119:
                        case 123:
                        case 125:
                        case 126:
                        case 129:
                        case 131:
                        case 132:
                        case 134:
                        case 138:
                        case 140:
                        case 142:
                        case 143:
                        case 144:
                        case 156:
                        case 160:
                        case 161:
                        case 162:
                        case 167:
                        case 170:
                        case 172:
                        case 173:
                        case 176:
                        case 180:
                        case 181:
                        case 191:
                        case 192:
                        case 198:
                        case 204:
                        case 219:
                        case 220:
                            goto IL_06eb;
                    }
                }
                switch (this.LA(1)) {
                    case 30:
                        token = this.LT(1);
                        this.match(30);
                        identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 118:
                    case 159:
                        break;
                }
                ConstraintDefinition constraintDefinition = this.uniqueColumnConstraint();
                if (base.inputState.guessing == 0) {
                    if (identifier != null) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(constraintDefinition, token);
                        constraintDefinition.ConstraintIdentifier = identifier;
                    }
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(columnDefinition, columnDefinition.Constraints, constraintDefinition);
                }
                goto IL_06eb;
            }
            switch (num) {
                case 106:
                case 118:
                case 119:
                case 123:
                case 125:
                case 126:
                case 127:
                case 129:
                case 131:
                case 132:
                case 134:
                case 136:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 159:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 192:
                case 198:
                case 204:
                case 219:
                case 220:
                case 232:
                case 233:
                    break;
                default:
                    goto IL_06d8;
            }
            goto IL_06c7;
            IL_06d8:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_06c7:
            this.regularColumnBody(columnDefinition);
            this.columnConstraintListOpt(statementType, columnDefinition);
            goto IL_06eb;
            IL_06eb:
            return columnDefinition;
            IL_06b4:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ConstraintDefinition tableConstraint(IndexAffectingStatement statementType, AlterTableAddTableElementStatement vStatement) {
            ConstraintDefinition constraintDefinition = null;
            IToken token = null;
            Identifier identifier = null;
            try {
                switch (this.LA(1)) {
                    case 30:
                        token = this.LT(1);
                        this.match(30);
                        identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 21:
                    case 47:
                    case 68:
                    case 118:
                    case 159:
                        break;
                }
                switch (this.LA(1)) {
                    case 118:
                    case 159:
                        constraintDefinition = this.uniqueTableConstraint();
                        break;
                    case 47:
                        constraintDefinition = this.defaultTableConstraint(statementType);
                        break;
                    case 68:
                        constraintDefinition = this.foreignKeyTableConstraint(statementType);
                        break;
                    case 21:
                        constraintDefinition = this.checkConstraint(statementType);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                if (base.inputState.guessing == 0) {
                    if (identifier != null) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(constraintDefinition, token);
                        constraintDefinition.ConstraintIdentifier = identifier;
                        return constraintDefinition;
                    }
                    return constraintDefinition;
                }
                return constraintDefinition;
            } catch (PhaseOneConstraintException ex) {
                if (base.inputState.guessing == 0) {
                    if (identifier != null) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(ex.Constraint, token);
                        ex.Constraint.ConstraintIdentifier = identifier;
                    }
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vStatement, vStatement.Definition.TableConstraints, ex.Constraint);
                    base.ThrowPartialAstIfPhaseOne(vStatement);
                    return constraintDefinition;
                }
                throw;
            }
        }

        public ScalarExpression expressionWithFlags(ExpressionFlags expressionFlags) {
            ScalarExpression scalarExpression = null;
            return this.expressionBinaryPri2(expressionFlags);
        }

        public UniqueConstraintDefinition uniqueColumnConstraint() {
            UniqueConstraintDefinition uniqueConstraintDefinition = base.FragmentFactory.CreateFragment<UniqueConstraintDefinition>();
            IToken token = null;
            this.uniqueConstraintHeader(uniqueConstraintDefinition, false);
            bool flag = false;
            if (this.LA(1) == 191 && (this.LA(2) == 200 || this.LA(2) == 232 || this.LA(2) == 233)) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.columnWithSortOrder();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                this.match(191);
                ColumnWithSortOrder item = this.columnWithSortOrder();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(uniqueConstraintDefinition, uniqueConstraintDefinition.Columns, item);
                }
                while (true) {
                    if (this.LA(1) != 198) {
                        break;
                    }
                    this.match(198);
                    item = this.columnWithSortOrder();
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(uniqueConstraintDefinition, uniqueConstraintDefinition.Columns, item);
                    }
                }
                token = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(uniqueConstraintDefinition, token);
                }
                goto IL_0171;
            }
            if (TSql80ParserInternal.tokenSet_71_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_72_.member(this.LA(2))) {
                goto IL_0171;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0171:
            this.uniqueConstraintTailOpt(uniqueConstraintDefinition);
            return uniqueConstraintDefinition;
        }

        public void regularColumnBody(ColumnDefinition vParent) {
            DataTypeReference dataTypeReference = null;
            int num = this.LA(1);
            if (num <= 100) {
                switch (num) {
                    case 53:
                    case 96:
                        break;
                    default:
                        goto IL_02f3;
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                        goto IL_0306;
                }
            } else {
                switch (num) {
                    case 232:
                    case 233:
                        break;
                    default:
                        goto IL_02f3;
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0306;
                }
            }
            dataTypeReference = this.scalarDataType();
            if (base.inputState.guessing == 0) {
                vParent.DataType = dataTypeReference;
            }
            this.collationOpt(vParent);
            goto IL_0306;
            IL_0306:
            if (base.inputState.guessing == 0) {
                base.VerifyColumnDataType(vParent);
            }
            return;
            IL_02f3:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void columnConstraintListOpt(IndexAffectingStatement statementType, ColumnDefinition vResult) {
            while (true) {
                switch (this.LA(1)) {
                    default:
                        return;
                    case 136:
                        this.rowguidcolConstraint(vResult);
                        break;
                    case 79: {
                            IdentityOptions identityOptions = this.identityConstraint(statementType);
                            if (base.inputState.guessing == 0) {
                                if (vResult.IdentityOptions != null) {
                                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46043", identityOptions, TSqlParserResource.SQL46043Message);
                                }
                                vResult.IdentityOptions = identityOptions;
                            }
                            break;
                        }
                    case 21:
                    case 30:
                    case 47:
                    case 68:
                    case 99:
                    case 100:
                    case 118:
                    case 127:
                    case 159: {
                            ConstraintDefinition constraint = this.columnConstraint(statementType);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddConstraintToColumn(constraint, vResult);
                            }
                            break;
                        }
                }
            }
        }

        public void rowguidcolConstraint(ColumnDefinition vParent) {
            IToken token = null;
            token = this.LT(1);
            this.match(136);
            if (base.inputState.guessing == 0) {
                if (vParent.IsRowGuidCol) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46042", token, TSqlParserResource.SQL46042Message);
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                vParent.IsRowGuidCol = true;
            }
        }

        public IdentityOptions identityConstraint(IndexAffectingStatement statementType) {
            IdentityOptions identityOptions = base.FragmentFactory.CreateFragment<IdentityOptions>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(79);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(identityOptions, token);
            }
            bool flag = false;
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_73_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.seedIncrement();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                this.match(191);
                ScalarExpression identitySeed = this.seedIncrement();
                if (base.inputState.guessing == 0) {
                    identityOptions.IdentitySeed = identitySeed;
                }
                this.match(198);
                identitySeed = this.seedIncrement();
                if (base.inputState.guessing == 0) {
                    identityOptions.IdentityIncrement = identitySeed;
                }
                token2 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(identityOptions, token2);
                }
                goto IL_015d;
            }
            if (TSql80ParserInternal.tokenSet_74_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_75_.member(this.LA(2))) {
                goto IL_015d;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_015d:
            bool isIdentityNotForReplication = this.replicationClauseOpt(statementType, identityOptions);
            if (base.inputState.guessing == 0) {
                identityOptions.IsIdentityNotForReplication = isIdentityNotForReplication;
            }
            return identityOptions;
        }

        public ConstraintDefinition columnConstraint(IndexAffectingStatement statementType) {
            ConstraintDefinition constraintDefinition = null;
            IToken token = null;
            Identifier identifier = null;
            try {
                switch (this.LA(1)) {
                    case 30:
                        token = this.LT(1);
                        this.match(30);
                        identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 21:
                    case 47:
                    case 68:
                    case 99:
                    case 100:
                    case 118:
                    case 127:
                    case 159:
                        break;
                }
                switch (this.LA(1)) {
                    case 99:
                    case 100:
                        constraintDefinition = this.nullableConstraint();
                        break;
                    case 47:
                        constraintDefinition = this.defaultColumnConstraint(statementType);
                        break;
                    case 118:
                    case 159:
                        constraintDefinition = this.uniqueColumnConstraint();
                        break;
                    case 68:
                    case 127:
                        constraintDefinition = this.foreignKeyColumnConstraint(statementType);
                        break;
                    case 21:
                        constraintDefinition = this.checkConstraint(statementType);
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                }
                if (base.inputState.guessing == 0) {
                    if (identifier != null) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(constraintDefinition, token);
                        constraintDefinition.ConstraintIdentifier = identifier;
                        return constraintDefinition;
                    }
                    return constraintDefinition;
                }
                return constraintDefinition;
            } catch (PhaseOneConstraintException) {
                if (base.inputState.guessing != 0) {
                    throw;
                }
                return constraintDefinition;
            }
        }

        public bool replicationClauseOpt(IndexAffectingStatement statementType, TSqlFragment vParent) {
            bool result = false;
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            if (this.LA(1) == 99 && this.LA(2) == 67) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(99);
                    this.match(67);
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                token = this.LT(1);
                this.match(99);
                this.match(67);
                token2 = this.LT(1);
                this.match(128);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                    TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                    result = true;
                }
                goto IL_00f3;
            }
            if (TSql80ParserInternal.tokenSet_74_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_76_.member(this.LA(2))) {
                goto IL_00f3;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_00f3:
            return result;
        }

        public NullableConstraintDefinition nullableConstraint() {
            NullableConstraintDefinition nullableConstraintDefinition = base.FragmentFactory.CreateFragment<NullableConstraintDefinition>();
            bool nullable = this.nullNotNull(nullableConstraintDefinition);
            if (base.inputState.guessing == 0) {
                nullableConstraintDefinition.Nullable = nullable;
            }
            return nullableConstraintDefinition;
        }

        public DefaultConstraintDefinition defaultColumnConstraint(IndexAffectingStatement statementType) {
            DefaultConstraintDefinition defaultConstraintDefinition = base.FragmentFactory.CreateFragment<DefaultConstraintDefinition>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(47);
            ScalarExpression expression = this.expressionWithFlags(ExpressionFlags.ScalarSubqueriesDisallowed);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(defaultConstraintDefinition, token);
                defaultConstraintDefinition.Expression = expression;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                        goto IL_037f;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(164);
                        if (base.inputState.guessing == 0) {
                            if (statementType != 0) {
                                TSql80ParserBaseInternal.ThrowParseErrorException("SQL46013", token, TSqlParserResource.SQL46013Message);
                            }
                            TSql80ParserBaseInternal.UpdateTokenInfo(defaultConstraintDefinition, token2);
                            defaultConstraintDefinition.WithValues = true;
                        }
                        goto IL_037f;
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_037f;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_037f:
            return defaultConstraintDefinition;
        }

        public ForeignKeyConstraintDefinition foreignKeyColumnConstraint(IndexAffectingStatement statementType) {
            ForeignKeyConstraintDefinition foreignKeyConstraintDefinition = base.FragmentFactory.CreateFragment<ForeignKeyConstraintDefinition>();
            IToken token = null;
            switch (this.LA(1)) {
                case 68:
                    token = this.LT(1);
                    this.match(68);
                    this.match(91);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                        TSql80ParserBaseInternal.UpdateTokenInfo(foreignKeyConstraintDefinition, token);
                    }
                    this.foreignConstraintColumnsOpt(foreignKeyConstraintDefinition);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 127:
                    break;
            }
            this.foreignKeyConstraintCommonEnd(statementType, foreignKeyConstraintDefinition);
            return foreignKeyConstraintDefinition;
        }

        public CheckConstraintDefinition checkConstraint(IndexAffectingStatement statementType) {
            CheckConstraintDefinition checkConstraintDefinition = base.FragmentFactory.CreateFragment<CheckConstraintDefinition>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(21);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(checkConstraintDefinition, token);
                base.ThrowConstraintIfPhaseOne(checkConstraintDefinition);
            }
            bool notForReplication = this.replicationClauseOpt(statementType, checkConstraintDefinition);
            if (base.inputState.guessing == 0) {
                checkConstraintDefinition.NotForReplication = notForReplication;
            }
            this.match(191);
            BooleanExpression checkCondition = this.booleanExpressionWithFlags(ExpressionFlags.ScalarSubqueriesDisallowed);
            if (base.inputState.guessing == 0) {
                checkConstraintDefinition.CheckCondition = checkCondition;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(checkConstraintDefinition, token2);
            }
            return checkConstraintDefinition;
        }

        public UniqueConstraintDefinition uniqueTableConstraint() {
            UniqueConstraintDefinition uniqueConstraintDefinition = base.FragmentFactory.CreateFragment<UniqueConstraintDefinition>();
            IToken token = null;
            this.uniqueConstraintHeader(uniqueConstraintDefinition, true);
            this.match(191);
            ColumnWithSortOrder item = this.columnWithSortOrder();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(uniqueConstraintDefinition, uniqueConstraintDefinition.Columns, item);
            }
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.columnWithSortOrder();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(uniqueConstraintDefinition, uniqueConstraintDefinition.Columns, item);
                }
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(uniqueConstraintDefinition, token);
            }
            this.uniqueConstraintTailOpt(uniqueConstraintDefinition);
            return uniqueConstraintDefinition;
        }

        public DefaultConstraintDefinition defaultTableConstraint(IndexAffectingStatement statementType) {
            DefaultConstraintDefinition defaultConstraintDefinition = base.FragmentFactory.CreateFragment<DefaultConstraintDefinition>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(47);
            if (base.inputState.guessing == 0) {
                if (statementType != 0) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46014", token, TSqlParserResource.SQL46014Message);
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(defaultConstraintDefinition, token);
                base.ThrowConstraintIfPhaseOne(defaultConstraintDefinition);
            }
            ScalarExpression expression = this.expressionWithFlags(ExpressionFlags.ScalarSubqueriesDisallowed);
            this.match(67);
            Identifier column = this.identifier();
            if (base.inputState.guessing == 0) {
                defaultConstraintDefinition.Expression = expression;
                defaultConstraintDefinition.Column = column;
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 74:
                    case 75:
                    case 82:
                    case 86:
                        goto IL_0352;
                }
            } else {
                switch (num) {
                    case 171:
                        this.match(171);
                        token2 = this.LT(1);
                        this.match(164);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(defaultConstraintDefinition, token2);
                            defaultConstraintDefinition.WithValues = true;
                        }
                        goto IL_0352;
                    case 92:
                    case 95:
                    case 106:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_0352;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0352:
            return defaultConstraintDefinition;
        }

        public ForeignKeyConstraintDefinition foreignKeyTableConstraint(IndexAffectingStatement statementType) {
            ForeignKeyConstraintDefinition foreignKeyConstraintDefinition = base.FragmentFactory.CreateFragment<ForeignKeyConstraintDefinition>();
            IToken token = null;
            token = this.LT(1);
            this.match(68);
            this.match(91);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(foreignKeyConstraintDefinition, token);
                base.ThrowConstraintIfPhaseOne(foreignKeyConstraintDefinition);
            }
            this.foreignConstraintColumnsOpt(foreignKeyConstraintDefinition);
            this.foreignKeyConstraintCommonEnd(statementType, foreignKeyConstraintDefinition);
            return foreignKeyConstraintDefinition;
        }

        public void uniqueConstraintHeader(UniqueConstraintDefinition vParent, bool throwInPhaseOne) {
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            switch (this.LA(1)) {
                case 159:
                    token = this.LT(1);
                    this.match(159);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                        vParent.IsPrimaryKey = false;
                    }
                    break;
                case 118:
                    token2 = this.LT(1);
                    this.match(118);
                    token3 = this.LT(1);
                    this.match(91);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token3);
                        vParent.IsPrimaryKey = true;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0 && throwInPhaseOne) {
                base.ThrowConstraintIfPhaseOne(vParent);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                        return;
                    case 24:
                        token4 = this.LT(1);
                        this.match(24);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token4);
                            vParent.Clustered = true;
                        }
                        return;
                }
            } else {
                switch (num) {
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                    case 105:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 98:
                        token5 = this.LT(1);
                        this.match(98);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token5);
                            vParent.Clustered = false;
                        }
                        return;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void uniqueConstraintTailOpt(UniqueConstraintDefinition vParent) {
            this.uniqueConstraintIndexOptionsOpt(vParent);
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                    case 92:
                        return;
                }
            } else {
                switch (num) {
                    case 95:
                    case 99:
                    case 100:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 105: {
                            this.LT(1);
                            this.match(105);
                            FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = this.filegroupOrPartitionScheme();
                            if (base.inputState.guessing == 0) {
                                vParent.OnFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
                            }
                            return;
                        }
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void uniqueConstraintIndexOptionsOpt(UniqueConstraintDefinition vParent) {
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                        return;
                }
            } else {
                switch (num) {
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                    case 105:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        return;
                    case 171:
                        this.match(171);
                        switch (this.LA(1)) {
                            case 66: {
                                    IndexOption item = this.fillFactorOption();
                                    if (base.inputState.guessing == 0) {
                                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.IndexOptions, item);
                                    }
                                    if (this.LA(1) == 232 && base.NextTokenMatchesOneOf("SORTED_DATA", "SORTED_DATA_REORG")) {
                                        this.sortedDataOptions();
                                    } else if (!TSql80ParserInternal.tokenSet_77_.member(this.LA(1))) {
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                    }
                                    break;
                                }
                            case 232: {
                                    this.sortedDataOptions();
                                    int num2 = this.LA(1);
                                    if (num2 <= 92) {
                                        switch (num2) {
                                            case 1:
                                            case 6:
                                            case 12:
                                            case 13:
                                            case 15:
                                            case 17:
                                            case 21:
                                            case 22:
                                            case 23:
                                            case 28:
                                            case 30:
                                            case 33:
                                            case 35:
                                            case 44:
                                            case 45:
                                            case 46:
                                            case 47:
                                            case 48:
                                            case 49:
                                            case 54:
                                            case 55:
                                            case 56:
                                            case 60:
                                            case 61:
                                            case 64:
                                            case 68:
                                            case 74:
                                            case 75:
                                            case 79:
                                            case 82:
                                            case 86:
                                            case 92:
                                                return;
                                            case 66: {
                                                    IndexOption item = this.fillFactorOption();
                                                    if (base.inputState.guessing == 0) {
                                                        TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.IndexOptions, item);
                                                    }
                                                    return;
                                                }
                                        }
                                    } else {
                                        switch (num2) {
                                            case 95:
                                            case 99:
                                            case 100:
                                            case 105:
                                            case 106:
                                            case 118:
                                            case 119:
                                            case 123:
                                            case 125:
                                            case 126:
                                            case 127:
                                            case 129:
                                            case 131:
                                            case 132:
                                            case 134:
                                            case 136:
                                            case 138:
                                            case 140:
                                            case 142:
                                            case 143:
                                            case 144:
                                            case 156:
                                            case 159:
                                            case 160:
                                            case 161:
                                            case 162:
                                            case 167:
                                            case 170:
                                            case 172:
                                            case 173:
                                            case 176:
                                            case 180:
                                            case 181:
                                            case 191:
                                            case 192:
                                            case 198:
                                            case 204:
                                            case 219:
                                            case 220:
                                                return;
                                        }
                                    }
                                    throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                        }
                        return;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void sortedDataOptions() {
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "SORTED_DATA", "SORTED_DATA_REORG");
            }
        }

        public DeleteUpdateAction deleteUpdateAction(TSqlFragment vParent) {
            DeleteUpdateAction result = DeleteUpdateAction.NoAction;
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            switch (this.LA(1)) {
                case 232:
                    token = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.Match(token, "NO");
                    }
                    token2 = this.LT(1);
                    this.match(232);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token2);
                        TSql80ParserBaseInternal.Match(token2, "ACTION");
                    }
                    break;
                case 19:
                    token3 = this.LT(1);
                    this.match(19);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token3);
                        result = DeleteUpdateAction.Cascade;
                    }
                    break;
                case 142:
                    this.match(142);
                    switch (this.LA(1)) {
                        case 100:
                            token4 = this.LT(1);
                            this.match(100);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token4);
                                result = DeleteUpdateAction.SetNull;
                            }
                            break;
                        case 47:
                            token5 = this.LT(1);
                            this.match(47);
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token5);
                                result = DeleteUpdateAction.SetDefault;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public void foreignKeyConstraintCommonEnd(IndexAffectingStatement statementType, ForeignKeyConstraintDefinition vParent) {
            IToken token = null;
            IToken token2 = null;
            bool flag = false;
            token = this.LT(1);
            this.match(127);
            SchemaObjectName referenceTableName = this.schemaObjectThreePartName();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.ThrowSyntaxErrorIfNotCreateAlterTable(statementType, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                vParent.ReferenceTableName = referenceTableName;
            }
            bool flag2 = false;
            if (this.LA(1) == 191 && (this.LA(2) == 232 || this.LA(2) == 233)) {
                int pos = this.mark();
                flag2 = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.identifier();
                } catch (RecognitionException) {
                    flag2 = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag2) {
                this.columnNameList(vParent, vParent.ReferencedTableColumns);
                goto IL_010d;
            }
            if (TSql80ParserInternal.tokenSet_77_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_75_.member(this.LA(2))) {
                goto IL_010d;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_01e4:
            int num = this.LA(1);
            if (num <= 92) {
                switch (num) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_082c;
                }
                goto IL_0819;
            }
            switch (num) {
                case 105:
                    break;
                default:
                    goto IL_0819;
                case 95:
                case 99:
                case 100:
                case 106:
                case 118:
                case 119:
                case 123:
                case 125:
                case 126:
                case 127:
                case 129:
                case 131:
                case 132:
                case 134:
                case 136:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 159:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 192:
                case 198:
                case 204:
                case 219:
                case 220:
                    goto IL_082c;
            }
            this.match(105);
            this.match(160);
            DeleteUpdateAction updateAction = this.deleteUpdateAction(vParent);
            if (base.inputState.guessing == 0) {
                vParent.UpdateAction = updateAction;
            }
            int num2 = this.LA(1);
            if (num2 <= 92) {
                switch (num2) {
                    case 1:
                    case 6:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                    case 92:
                        goto IL_082c;
                }
                goto IL_0806;
            }
            switch (num2) {
                case 105:
                    break;
                default:
                    goto IL_0806;
                case 95:
                case 99:
                case 100:
                case 106:
                case 118:
                case 119:
                case 123:
                case 125:
                case 126:
                case 127:
                case 129:
                case 131:
                case 132:
                case 134:
                case 136:
                case 138:
                case 140:
                case 142:
                case 143:
                case 144:
                case 156:
                case 159:
                case 160:
                case 161:
                case 162:
                case 167:
                case 170:
                case 172:
                case 173:
                case 176:
                case 180:
                case 181:
                case 191:
                case 192:
                case 198:
                case 204:
                case 219:
                case 220:
                    goto IL_082c;
            }
            token2 = this.LT(1);
            this.match(105);
            this.match(48);
            updateAction = this.deleteUpdateAction(vParent);
            if (base.inputState.guessing == 0) {
                if (flag) {
                    throw TSql80ParserBaseInternal.GetUnexpectedTokenErrorException(token2);
                }
                vParent.DeleteAction = updateAction;
            }
            goto IL_082c;
            IL_0819:
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_082c:
            bool notForReplication = this.replicationClauseOpt(statementType, vParent);
            if (base.inputState.guessing == 0) {
                vParent.NotForReplication = notForReplication;
            }
            return;
            IL_010d:
            bool flag3 = false;
            if (this.LA(1) == 105 && this.LA(2) == 48) {
                int pos2 = this.mark();
                flag3 = true;
                base.inputState.guessing++;
                try {
                    this.match(105);
                    this.match(48);
                } catch (RecognitionException) {
                    flag3 = false;
                }
                this.rewind(pos2);
                base.inputState.guessing--;
            }
            if (flag3) {
                this.match(105);
                this.match(48);
                updateAction = this.deleteUpdateAction(vParent);
                if (base.inputState.guessing == 0) {
                    vParent.DeleteAction = updateAction;
                    flag = true;
                }
                goto IL_01e4;
            }
            if (TSql80ParserInternal.tokenSet_77_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_75_.member(this.LA(2))) {
                goto IL_01e4;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_0806:
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void foreignConstraintColumnsOpt(ForeignKeyConstraintDefinition vParent) {
            switch (this.LA(1)) {
                case 127:
                    break;
                case 191:
                    this.columnNameList(vParent, vParent.Columns);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public BooleanExpression booleanExpressionWithFlags(ExpressionFlags expressionFlags) {
            BooleanExpression booleanExpression = null;
            return this.booleanExpressionOr(expressionFlags);
        }

        public SqlDataTypeReference sqlDataTypeWithoutNational(SchemaObjectName vName, SqlDataTypeOption vType) {
            SqlDataTypeReference sqlDataTypeReference = base.FragmentFactory.CreateFragment<SqlDataTypeReference>();
            IToken token = null;
            sqlDataTypeReference.Name = vName;
            sqlDataTypeReference.SqlDataTypeOption = vType;
            sqlDataTypeReference.UpdateTokenInfo(vName);
            bool isVarying = false;
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 9:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 26:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                        goto IL_035c;
                }
            } else {
                switch (num) {
                    case 165:
                        token = this.LT(1);
                        this.match(165);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(sqlDataTypeReference, token);
                            isVarying = true;
                        }
                        goto IL_035c;
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 206:
                    case 219:
                    case 220:
                    case 230:
                    case 231:
                    case 232:
                    case 234:
                        goto IL_035c;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_035c:
            this.dataTypeParametersOpt(sqlDataTypeReference);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.ProcessNationalAndVarying(sqlDataTypeReference, null, isVarying);
                TSql80ParserBaseInternal.CheckSqlDataTypeParameters(sqlDataTypeReference);
            }
            return sqlDataTypeReference;
        }

        public UserDataTypeReference userDataType(SchemaObjectName vName) {
            UserDataTypeReference userDataTypeReference = base.FragmentFactory.CreateFragment<UserDataTypeReference>();
            userDataTypeReference.Name = vName;
            userDataTypeReference.UpdateTokenInfo(vName);
            this.dataTypeParametersOpt(userDataTypeReference);
            return userDataTypeReference;
        }

        public SqlDataTypeReference doubleDataType() {
            SqlDataTypeReference sqlDataTypeReference = base.FragmentFactory.CreateFragment<SqlDataTypeReference>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            token = this.LT(1);
            this.match(53);
            token2 = this.LT(1);
            this.match(174);
            if (base.inputState.guessing == 0) {
                base.SetNameForDoublePrecisionType(sqlDataTypeReference, token, token2);
                sqlDataTypeReference.SqlDataTypeOption = SqlDataTypeOption.Float;
            }
            bool flag = false;
            if (this.LA(1) == 191 && this.LA(2) == 221) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    switch (this.LA(1)) {
                        case 221:
                            this.integer();
                            break;
                        case 232:
                            this.match(232);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                this.match(191);
                Literal item = this.integer();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(sqlDataTypeReference, sqlDataTypeReference.Parameters, item);
                }
                token3 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(sqlDataTypeReference, token3);
                }
                goto IL_019e;
            }
            if (TSql80ParserInternal.tokenSet_2_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_1_.member(this.LA(2))) {
                goto IL_019e;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_019e:
            return sqlDataTypeReference;
        }

        public SqlDataTypeReference sqlDataTypeWithNational() {
            SqlDataTypeReference sqlDataTypeReference = base.FragmentFactory.CreateFragment<SqlDataTypeReference>();
            IToken token = null;
            IToken token2 = null;
            bool isVarying = false;
            token = this.LT(1);
            this.match(96);
            Identifier identifier = this.identifier();
            if (base.inputState.guessing == 0) {
                sqlDataTypeReference.SqlDataTypeOption = TSql80ParserBaseInternal.ParseDataType(identifier.Value);
                if (sqlDataTypeReference.SqlDataTypeOption == SqlDataTypeOption.None) {
                    TSql80ParserBaseInternal.ThrowParseErrorException("SQL46003", token, TSqlParserResource.SQL46003Message, TSqlParserResource.UserDefined);
                }
                sqlDataTypeReference.Name = base.FragmentFactory.CreateFragment<SchemaObjectName>();
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(sqlDataTypeReference.Name, sqlDataTypeReference.Name.Identifiers, identifier);
                TSql80ParserBaseInternal.UpdateTokenInfo(sqlDataTypeReference, token);
                sqlDataTypeReference.UpdateTokenInfo(identifier);
            }
            int num = this.LA(1);
            if (num <= 86) {
                switch (num) {
                    case 1:
                    case 6:
                    case 9:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 21:
                    case 22:
                    case 23:
                    case 26:
                    case 28:
                    case 30:
                    case 33:
                    case 35:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 68:
                    case 74:
                    case 75:
                    case 79:
                    case 82:
                    case 86:
                        goto IL_03fe;
                }
            } else {
                switch (num) {
                    case 165:
                        token2 = this.LT(1);
                        this.match(165);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(sqlDataTypeReference, token2);
                            isVarying = true;
                        }
                        goto IL_03fe;
                    case 92:
                    case 95:
                    case 99:
                    case 100:
                    case 106:
                    case 118:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 127:
                    case 129:
                    case 131:
                    case 132:
                    case 134:
                    case 136:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 156:
                    case 159:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 198:
                    case 204:
                    case 206:
                    case 219:
                    case 220:
                    case 230:
                    case 231:
                    case 232:
                    case 234:
                        goto IL_03fe;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_03fe:
            this.dataTypeParametersOpt(sqlDataTypeReference);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.ProcessNationalAndVarying(sqlDataTypeReference, token, isVarying);
                TSql80ParserBaseInternal.CheckSqlDataTypeParameters(sqlDataTypeReference);
            }
            return sqlDataTypeReference;
        }

        public void dataTypeParametersOpt(ParameterizedDataTypeReference vParent) {
            IToken token = null;
            bool flag = false;
            if (this.LA(1) == 191 && this.LA(2) == 221) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.match(191);
                    this.integer();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                this.match(191);
                Literal item = this.integer();
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
                }
                switch (this.LA(1)) {
                    case 198:
                        this.match(198);
                        item = this.integer();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
                        }
                        break;
                    default:
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    case 192:
                        break;
                }
                token = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
                }
                return;
            }
            if (TSql80ParserInternal.tokenSet_2_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_1_.member(this.LA(2))) {
                return;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public void identifierListElement(List<Identifier> vParent, int vMaxNumber, bool first) {
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(200);
            Identifier emptyIdentifier;
            if (base.inputState.guessing == 0 && first) {
                emptyIdentifier = base.GetEmptyIdentifier(token);
                TSql80ParserBaseInternal.AddIdentifierToListWithCheck(vParent, emptyIdentifier, vMaxNumber);
            }
            while (true) {
                if (this.LA(1) != 200) {
                    break;
                }
                token2 = this.LT(1);
                this.match(200);
                if (base.inputState.guessing == 0) {
                    emptyIdentifier = base.GetEmptyIdentifier(token2);
                    TSql80ParserBaseInternal.AddIdentifierToListWithCheck(vParent, emptyIdentifier, vMaxNumber);
                }
            }
            emptyIdentifier = this.identifier();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddIdentifierToListWithCheck(vParent, emptyIdentifier, vMaxNumber);
            }
        }

        public BooleanExpression booleanExpressionOr(ExpressionFlags expressionFlags) {
            BooleanExpression result = null;
            result = this.booleanExpressionAnd(expressionFlags);
            while (true) {
                if (this.LA(1) != 112) {
                    break;
                }
                this.match(112);
                BooleanExpression expression = this.booleanExpressionAnd(expressionFlags);
                if (base.inputState.guessing == 0) {
                    base.AddBinaryExpression(ref result, expression, BooleanBinaryExpressionType.Or);
                }
            }
            return result;
        }

        public BooleanExpression booleanExpressionAnd(ExpressionFlags expressionFlags) {
            BooleanExpression result = null;
            result = this.booleanExpressionUnary(expressionFlags);
            while (true) {
                if (this.LA(1) != 7) {
                    break;
                }
                this.match(7);
                BooleanExpression expression = this.booleanExpressionUnary(expressionFlags);
                if (base.inputState.guessing == 0) {
                    base.AddBinaryExpression(ref result, expression, BooleanBinaryExpressionType.And);
                }
            }
            return result;
        }

        public BooleanExpression booleanExpressionUnary(ExpressionFlags expressionFlags) {
            BooleanExpression result = null;
            IToken token = null;
            switch (this.LA(1)) {
                case 99: {
                        token = this.LT(1);
                        this.match(99);
                        BooleanExpression expression = this.booleanExpressionUnary(expressionFlags);
                        if (base.inputState.guessing == 0) {
                            BooleanNotExpression booleanNotExpression = base.FragmentFactory.CreateFragment<BooleanNotExpression>();
                            result = booleanNotExpression;
                            TSql80ParserBaseInternal.UpdateTokenInfo(booleanNotExpression, token);
                            booleanNotExpression.Expression = expression;
                        }
                        break;
                    }
                case 20:
                case 25:
                case 31:
                case 34:
                case 40:
                case 41:
                case 62:
                case 69:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 157:
                case 160:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    result = this.booleanExpressionPrimary(expressionFlags);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public BooleanExpression booleanExpressionPrimary(ExpressionFlags expressionFlags) {
            BooleanExpression booleanExpression = null;
            IToken token = null;
            bool vNotDefined = false;
            BooleanComparisonType vType = BooleanComparisonType.Equals;
            switch (this.LA(1)) {
                case 31:
                case 69:
                    booleanExpression = this.fulltextPredicate();
                    break;
                case 62:
                    booleanExpression = this.existsPredicate(expressionFlags);
                    break;
                case 157:
                    booleanExpression = this.tsEqualCall();
                    break;
                case 160:
                    booleanExpression = this.updateCall();
                    break;
                default:
                    if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_51_.member(this.LA(2)) && base.IsNextRuleBooleanParenthesis()) {
                        booleanExpression = this.booleanExpressionParenthesis();
                        break;
                    }
                    if (TSql80ParserInternal.tokenSet_16_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_78_.member(this.LA(2))) {
                        ScalarExpression vExpressionFirst = this.expressionWithFlags(expressionFlags);
                        switch (this.LA(1)) {
                            case 188:
                            case 205:
                            case 206:
                            case 208:
                                vType = this.comparisonOperator();
                                switch (this.LA(1)) {
                                    case 20:
                                    case 25:
                                    case 34:
                                    case 40:
                                    case 41:
                                    case 81:
                                    case 93:
                                    case 100:
                                    case 101:
                                    case 133:
                                    case 136:
                                    case 141:
                                    case 147:
                                    case 163:
                                    case 191:
                                    case 193:
                                    case 197:
                                    case 199:
                                    case 200:
                                    case 211:
                                    case 221:
                                    case 222:
                                    case 223:
                                    case 224:
                                    case 225:
                                    case 227:
                                    case 228:
                                    case 230:
                                    case 231:
                                    case 232:
                                    case 233:
                                    case 234:
                                    case 235:
                                        booleanExpression = this.comparisonPredicate(vExpressionFirst, vType, expressionFlags);
                                        break;
                                    case 5:
                                    case 8:
                                    case 145:
                                        booleanExpression = this.subqueryComparisonPredicate(vExpressionFirst, vType, expressionFlags);
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                                break;
                            case 196:
                            case 207:
                                booleanExpression = this.joinPredicate(vExpressionFirst, vType, expressionFlags);
                                break;
                            case 89:
                                booleanExpression = this.isPredicate(vExpressionFirst);
                                break;
                            case 14:
                            case 83:
                            case 94:
                            case 99:
                                switch (this.LA(1)) {
                                    case 99:
                                        token = this.LT(1);
                                        this.match(99);
                                        if (base.inputState.guessing == 0) {
                                            vNotDefined = true;
                                        }
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                    case 14:
                                    case 83:
                                    case 94:
                                        break;
                                }
                                switch (this.LA(1)) {
                                    case 83:
                                        booleanExpression = this.inPredicate(vExpressionFirst, vNotDefined, expressionFlags);
                                        break;
                                    case 14:
                                        booleanExpression = this.betweenPredicate(vExpressionFirst, vNotDefined, expressionFlags);
                                        break;
                                    case 94:
                                        booleanExpression = this.likePredicate(vExpressionFirst, vNotDefined, expressionFlags);
                                        break;
                                    default:
                                        throw new NoViableAltException(this.LT(1), this.getFilename());
                                }
                                if (base.inputState.guessing == 0 && token != null) {
                                    TSql80ParserBaseInternal.UpdateTokenInfo(booleanExpression, token);
                                }
                                break;
                            default:
                                throw new NoViableAltException(this.LT(1), this.getFilename());
                        }
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return booleanExpression;
        }

        public BooleanParenthesisExpression booleanExpressionParenthesis() {
            BooleanParenthesisExpression booleanParenthesisExpression = base.FragmentFactory.CreateFragment<BooleanParenthesisExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            BooleanExpression expression = this.booleanExpression();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(booleanParenthesisExpression, token);
                booleanParenthesisExpression.Expression = expression;
                TSql80ParserBaseInternal.UpdateTokenInfo(booleanParenthesisExpression, token2);
            }
            return booleanParenthesisExpression;
        }

        public BooleanComparisonType comparisonOperator() {
            BooleanComparisonType result = BooleanComparisonType.Equals;
            switch (this.LA(1)) {
                case 206:
                    this.match(206);
                    if (base.inputState.guessing == 0) {
                        result = BooleanComparisonType.Equals;
                    }
                    break;
                case 208:
                    this.match(208);
                    if (base.inputState.guessing == 0) {
                        result = BooleanComparisonType.GreaterThan;
                    }
                    switch (this.LA(1)) {
                        case 206:
                            this.match(206);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.GreaterThanOrEqualTo;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 5:
                        case 8:
                        case 20:
                        case 25:
                        case 34:
                        case 40:
                        case 41:
                        case 81:
                        case 93:
                        case 100:
                        case 101:
                        case 133:
                        case 136:
                        case 141:
                        case 145:
                        case 147:
                        case 163:
                        case 191:
                        case 193:
                        case 197:
                        case 199:
                        case 200:
                        case 211:
                        case 221:
                        case 222:
                        case 223:
                        case 224:
                        case 225:
                        case 227:
                        case 228:
                        case 230:
                        case 231:
                        case 232:
                        case 233:
                        case 234:
                        case 235:
                            break;
                    }
                    break;
                case 205:
                    this.match(205);
                    if (base.inputState.guessing == 0) {
                        result = BooleanComparisonType.LessThan;
                    }
                    switch (this.LA(1)) {
                        case 206:
                            this.match(206);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.LessThanOrEqualTo;
                            }
                            break;
                        case 208:
                            this.match(208);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.NotEqualToBrackets;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 5:
                        case 8:
                        case 20:
                        case 25:
                        case 34:
                        case 40:
                        case 41:
                        case 81:
                        case 93:
                        case 100:
                        case 101:
                        case 133:
                        case 136:
                        case 141:
                        case 145:
                        case 147:
                        case 163:
                        case 191:
                        case 193:
                        case 197:
                        case 199:
                        case 200:
                        case 211:
                        case 221:
                        case 222:
                        case 223:
                        case 224:
                        case 225:
                        case 227:
                        case 228:
                        case 230:
                        case 231:
                        case 232:
                        case 233:
                        case 234:
                        case 235:
                            break;
                    }
                    break;
                case 188:
                    this.match(188);
                    switch (this.LA(1)) {
                        case 206:
                            this.match(206);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.NotEqualToExclamation;
                            }
                            break;
                        case 205:
                            this.match(205);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.NotLessThan;
                            }
                            break;
                        case 208:
                            this.match(208);
                            if (base.inputState.guessing == 0) {
                                result = BooleanComparisonType.NotGreaterThan;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public BooleanComparisonExpression comparisonPredicate(ScalarExpression vExpressionFirst, BooleanComparisonType vType, ExpressionFlags expressionFlags) {
            BooleanComparisonExpression booleanComparisonExpression = base.FragmentFactory.CreateFragment<BooleanComparisonExpression>();
            ScalarExpression secondExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                booleanComparisonExpression.ComparisonType = vType;
                booleanComparisonExpression.FirstExpression = vExpressionFirst;
                booleanComparisonExpression.SecondExpression = secondExpression;
            }
            return booleanComparisonExpression;
        }

        public SubqueryComparisonPredicate subqueryComparisonPredicate(ScalarExpression vExpressionFirst, BooleanComparisonType vType, ExpressionFlags expressionFlags) {
            SubqueryComparisonPredicate subqueryComparisonPredicate = base.FragmentFactory.CreateFragment<SubqueryComparisonPredicate>();
            SubqueryComparisonPredicateType subqueryComparisonPredicateType = SubqueryComparisonPredicateType.None;
            subqueryComparisonPredicateType = this.subqueryComparisonPredicateType();
            ScalarSubquery subquery = this.subquery(expressionFlags);
            if (base.inputState.guessing == 0) {
                subqueryComparisonPredicate.ComparisonType = vType;
                subqueryComparisonPredicate.Expression = vExpressionFirst;
                subqueryComparisonPredicate.SubqueryComparisonPredicateType = subqueryComparisonPredicateType;
                subqueryComparisonPredicate.Subquery = subquery;
            }
            return subqueryComparisonPredicate;
        }

        public BooleanComparisonExpression joinPredicate(ScalarExpression vExpressionFirst, BooleanComparisonType vType, ExpressionFlags expressionFlags) {
            BooleanComparisonExpression booleanComparisonExpression = base.FragmentFactory.CreateFragment<BooleanComparisonExpression>();
            vType = this.joinOperator();
            ScalarExpression secondExpression = this.expression();
            if (base.inputState.guessing == 0) {
                booleanComparisonExpression.ComparisonType = vType;
                booleanComparisonExpression.FirstExpression = vExpressionFirst;
                booleanComparisonExpression.SecondExpression = secondExpression;
            }
            return booleanComparisonExpression;
        }

        public BooleanIsNullExpression isPredicate(ScalarExpression vExpressionFirst) {
            BooleanIsNullExpression booleanIsNullExpression = base.FragmentFactory.CreateFragment<BooleanIsNullExpression>();
            this.match(89);
            bool flag = this.nullNotNull(booleanIsNullExpression);
            if (base.inputState.guessing == 0) {
                booleanIsNullExpression.Expression = vExpressionFirst;
                booleanIsNullExpression.IsNot = !flag;
            }
            return booleanIsNullExpression;
        }

        public InPredicate inPredicate(ScalarExpression vExpressionFirst, bool vNotDefined, ExpressionFlags expressionFlags) {
            InPredicate inPredicate = base.FragmentFactory.CreateFragment<InPredicate>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(83);
            if (base.inputState.guessing == 0) {
                if (vNotDefined) {
                    inPredicate.NotDefined = true;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(inPredicate, token);
                inPredicate.Expression = vExpressionFirst;
            }
            if (this.LA(1) == 191 && (this.LA(2) == 140 || this.LA(2) == 191) && base.IsNextRuleSelectParenthesis()) {
                ScalarSubquery subquery = this.subquery(expressionFlags);
                if (base.inputState.guessing == 0) {
                    inPredicate.Subquery = subquery;
                }
                goto IL_010a;
            }
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_16_.member(this.LA(2))) {
                this.match(191);
                this.expressionList(inPredicate, inPredicate.Values);
                token2 = this.LT(1);
                this.match(192);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.UpdateTokenInfo(inPredicate, token2);
                }
                goto IL_010a;
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_010a:
            return inPredicate;
        }

        public BooleanTernaryExpression betweenPredicate(ScalarExpression vExpressionFirst, bool vNotDefined, ExpressionFlags expressionFlags) {
            BooleanTernaryExpression booleanTernaryExpression = base.FragmentFactory.CreateFragment<BooleanTernaryExpression>();
            IToken token = null;
            token = this.LT(1);
            this.match(14);
            ScalarExpression secondExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                booleanTernaryExpression.SecondExpression = secondExpression;
            }
            this.match(7);
            secondExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                booleanTernaryExpression.ThirdExpression = secondExpression;
                if (vNotDefined) {
                    booleanTernaryExpression.TernaryExpressionType = BooleanTernaryExpressionType.NotBetween;
                } else {
                    booleanTernaryExpression.TernaryExpressionType = BooleanTernaryExpressionType.Between;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(booleanTernaryExpression, token);
                booleanTernaryExpression.FirstExpression = vExpressionFirst;
            }
            return booleanTernaryExpression;
        }

        public LikePredicate likePredicate(ScalarExpression vExpressionFirst, bool vNotDefined, ExpressionFlags expressionFlags) {
            LikePredicate likePredicate = base.FragmentFactory.CreateFragment<LikePredicate>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(94);
            if (base.inputState.guessing == 0) {
                if (vNotDefined) {
                    likePredicate.NotDefined = true;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(likePredicate, token);
                likePredicate.FirstExpression = vExpressionFirst;
            }
            ScalarExpression secondExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                likePredicate.SecondExpression = secondExpression;
            }
            int num = this.LA(1);
            if (num <= 95) {
                switch (num) {
                    case 58:
                        this.escapeExpression(likePredicate, expressionFlags);
                        goto IL_03d9;
                    case 1:
                    case 6:
                    case 7:
                    case 12:
                    case 13:
                    case 15:
                    case 17:
                    case 22:
                    case 23:
                    case 28:
                    case 29:
                    case 33:
                    case 35:
                    case 36:
                    case 44:
                    case 45:
                    case 46:
                    case 48:
                    case 49:
                    case 54:
                    case 55:
                    case 56:
                    case 59:
                    case 60:
                    case 61:
                    case 64:
                    case 67:
                    case 72:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 82:
                    case 85:
                    case 86:
                    case 87:
                    case 90:
                    case 92:
                    case 93:
                    case 95:
                        goto IL_03d9;
                }
            } else {
                switch (num) {
                    case 193:
                        this.match(193);
                        if (base.inputState.guessing == 0) {
                            likePredicate.OdbcEscape = true;
                        }
                        this.escapeExpression(likePredicate, expressionFlags);
                        token2 = this.LT(1);
                        this.match(194);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(likePredicate, token2);
                        }
                        goto IL_03d9;
                    case 105:
                    case 106:
                    case 111:
                    case 112:
                    case 113:
                    case 114:
                    case 119:
                    case 123:
                    case 125:
                    case 126:
                    case 129:
                    case 131:
                    case 132:
                    case 133:
                    case 134:
                    case 138:
                    case 140:
                    case 142:
                    case 143:
                    case 144:
                    case 150:
                    case 156:
                    case 158:
                    case 160:
                    case 161:
                    case 162:
                    case 167:
                    case 169:
                    case 170:
                    case 171:
                    case 172:
                    case 173:
                    case 176:
                    case 180:
                    case 181:
                    case 191:
                    case 192:
                    case 194:
                    case 198:
                    case 204:
                    case 219:
                    case 220:
                        goto IL_03d9;
                }
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
            IL_03d9:
            return likePredicate;
        }

        public FullTextPredicate fulltextPredicate() {
            FullTextPredicate fullTextPredicate = base.FragmentFactory.CreateFragment<FullTextPredicate>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            switch (this.LA(1)) {
                case 31:
                    token = this.LT(1);
                    this.match(31);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(fullTextPredicate, token);
                        fullTextPredicate.FullTextFunctionType = FullTextFunctionType.Contains;
                    }
                    break;
                case 69:
                    token2 = this.LT(1);
                    this.match(69);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(fullTextPredicate, token2);
                        fullTextPredicate.FullTextFunctionType = FullTextFunctionType.FreeText;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            this.match(191);
            switch (this.LA(1)) {
                case 81:
                case 136:
                case 195:
                case 200:
                case 227:
                case 232:
                case 233: {
                        ColumnReferenceExpression item = this.fulltextColumn();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fullTextPredicate, fullTextPredicate.Columns, item);
                        }
                        break;
                    }
                case 191: {
                        this.match(191);
                        bool flag = false;
                        if (TSql80ParserInternal.tokenSet_35_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_79_.member(this.LA(2))) {
                            int pos = this.mark();
                            flag = true;
                            base.inputState.guessing++;
                            try {
                                this.starColumn();
                            } catch (RecognitionException) {
                                flag = false;
                            }
                            this.rewind(pos);
                            base.inputState.guessing--;
                        }
                        if (flag) {
                            ColumnReferenceExpression item = this.starColumn();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fullTextPredicate, fullTextPredicate.Columns, item);
                            }
                            goto IL_0283;
                        }
                        if (TSql80ParserInternal.tokenSet_80_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_81_.member(this.LA(2))) {
                            ColumnReferenceExpression item = this.column();
                            if (base.inputState.guessing == 0) {
                                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fullTextPredicate, fullTextPredicate.Columns, item);
                            }
                            while (true) {
                                if (this.LA(1) != 198) {
                                    break;
                                }
                                this.match(198);
                                item = this.column();
                                if (base.inputState.guessing == 0) {
                                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(fullTextPredicate, fullTextPredicate.Columns, item);
                                }
                            }
                            goto IL_0283;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                default: {
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    IL_0283:
                    this.match(192);
                    break;
            }
            this.match(198);
            ValueExpression value = this.stringOrVariable();
            if (base.inputState.guessing == 0) {
                fullTextPredicate.Value = value;
            }
            switch (this.LA(1)) {
                case 198: {
                        this.match(198);
                        ValueExpression languageTerm = this.languageExpression();
                        if (base.inputState.guessing == 0) {
                            fullTextPredicate.LanguageTerm = languageTerm;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token3 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(fullTextPredicate, token3);
            }
            return fullTextPredicate;
        }

        public ExistsPredicate existsPredicate(ExpressionFlags expressionFlags) {
            ExistsPredicate existsPredicate = base.FragmentFactory.CreateFragment<ExistsPredicate>();
            this.match(62);
            ScalarSubquery subquery = this.subquery(expressionFlags);
            if (base.inputState.guessing == 0) {
                existsPredicate.Subquery = subquery;
            }
            return existsPredicate;
        }

        public TSEqualCall tsEqualCall() {
            TSEqualCall tSEqualCall = base.FragmentFactory.CreateFragment<TSEqualCall>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(157);
            this.match(191);
            ScalarExpression firstExpression = this.expression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(tSEqualCall, token);
                tSEqualCall.FirstExpression = firstExpression;
            }
            this.match(198);
            firstExpression = this.expression();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                tSEqualCall.SecondExpression = firstExpression;
                TSql80ParserBaseInternal.UpdateTokenInfo(tSEqualCall, token2);
            }
            return tSEqualCall;
        }

        public UpdateCall updateCall() {
            UpdateCall updateCall = base.FragmentFactory.CreateFragment<UpdateCall>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(160);
            this.match(191);
            Identifier identifier = this.identifier();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(updateCall, token);
                updateCall.Identifier = identifier;
                TSql80ParserBaseInternal.UpdateTokenInfo(updateCall, token2);
            }
            return updateCall;
        }

        public ColumnReferenceExpression fulltextColumn() {
            ColumnReferenceExpression columnReferenceExpression = null;
            bool flag = false;
            if (TSql80ParserInternal.tokenSet_35_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_82_.member(this.LA(2))) {
                int pos = this.mark();
                flag = true;
                base.inputState.guessing++;
                try {
                    this.starColumn();
                } catch (RecognitionException) {
                    flag = false;
                }
                this.rewind(pos);
                base.inputState.guessing--;
            }
            if (flag) {
                return this.starColumn();
            }
            if (TSql80ParserInternal.tokenSet_80_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_82_.member(this.LA(2))) {
                return this.column();
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ColumnReferenceExpression starColumn() {
            ColumnReferenceExpression columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
            IToken token = null;
            IToken token2 = null;
            columnReferenceExpression.ColumnType = ColumnType.Wildcard;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233: {
                        MultiPartIdentifier multiPartIdentifier = this.multiPartIdentifier(-1);
                        if (base.inputState.guessing == 0) {
                            columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
                        }
                        this.match(200);
                        token = this.LT(1);
                        this.match(195);
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.UpdateTokenInfo(columnReferenceExpression, token);
                            columnReferenceExpression.ColumnType = ColumnType.Wildcard;
                        }
                        break;
                    }
                case 195:
                    token2 = this.LT(1);
                    this.match(195);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(columnReferenceExpression, token2);
                        columnReferenceExpression.ColumnType = ColumnType.Wildcard;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.CheckSpecialColumn(columnReferenceExpression);
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(columnReferenceExpression, false);
            }
            return columnReferenceExpression;
        }

        public BooleanComparisonType joinOperator() {
            BooleanComparisonType result = BooleanComparisonType.LeftOuterJoin;
            switch (this.LA(1)) {
                case 196:
                    this.match(196);
                    if (base.inputState.guessing == 0) {
                        result = BooleanComparisonType.LeftOuterJoin;
                    }
                    break;
                case 207:
                    this.match(207);
                    if (base.inputState.guessing == 0) {
                        result = BooleanComparisonType.RightOuterJoin;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public SubqueryComparisonPredicateType subqueryComparisonPredicateType() {
            SubqueryComparisonPredicateType result = SubqueryComparisonPredicateType.None;
            switch (this.LA(1)) {
                case 5:
                    this.match(5);
                    if (base.inputState.guessing == 0) {
                        result = SubqueryComparisonPredicateType.All;
                    }
                    break;
                case 8:
                    this.match(8);
                    if (base.inputState.guessing == 0) {
                        result = SubqueryComparisonPredicateType.Any;
                    }
                    break;
                case 145:
                    this.match(145);
                    if (base.inputState.guessing == 0) {
                        result = SubqueryComparisonPredicateType.Any;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public void escapeExpression(LikePredicate vParent, ExpressionFlags expressionFlags) {
            this.match(58);
            ScalarExpression escapeExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                vParent.EscapeExpression = escapeExpression;
            }
        }

        public ScalarExpression expressionBinaryPri2(ExpressionFlags expressionFlags) {
            ScalarExpression result = null;
            result = this.expressionBinaryPri1(expressionFlags);
            while (true) {
                switch (this.LA(1)) {
                    case 197: {
                            this.match(197);
                            ScalarExpression expression = this.expressionBinaryPri1(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.Add);
                            }
                            break;
                        }
                    case 199: {
                            this.match(199);
                            ScalarExpression expression = this.expressionBinaryPri1(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.Subtract);
                            }
                            break;
                        }
                    case 190: {
                            this.match(190);
                            ScalarExpression expression = this.expressionBinaryPri1(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.BitwiseAnd);
                            }
                            break;
                        }
                    case 210: {
                            this.match(210);
                            ScalarExpression expression = this.expressionBinaryPri1(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.BitwiseOr);
                            }
                            break;
                        }
                    case 209: {
                            this.match(209);
                            ScalarExpression expression = this.expressionBinaryPri1(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.BitwiseXor);
                            }
                            break;
                        }
                    default:
                        return result;
                }
            }
        }

        public ScalarExpression expressionBinaryPri1(ExpressionFlags expressionFlags) {
            ScalarExpression result = null;
            result = this.expressionUnary(expressionFlags);
            while (true) {
                switch (this.LA(1)) {
                    case 195: {
                            this.match(195);
                            ScalarExpression expression = this.expressionUnary(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.Multiply);
                            }
                            break;
                        }
                    case 201: {
                            this.match(201);
                            ScalarExpression expression = this.expressionUnary(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.Divide);
                            }
                            break;
                        }
                    case 189: {
                            this.match(189);
                            ScalarExpression expression = this.expressionUnary(expressionFlags);
                            if (base.inputState.guessing == 0) {
                                base.AddBinaryExpression(ref result, expression, BinaryExpressionType.Modulo);
                            }
                            break;
                        }
                    default:
                        return result;
                }
            }
        }

        public ScalarExpression expressionUnary(ExpressionFlags expressionFlags) {
            ScalarExpression result = null;
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            ScalarExpression scalarExpression = null;
            UnaryExpression unaryExpression = null;
            switch (this.LA(1)) {
                case 197:
                case 199:
                case 211:
                    switch (this.LA(1)) {
                        case 197:
                            token = this.LT(1);
                            this.match(197);
                            if (base.inputState.guessing == 0) {
                                unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                                TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token);
                                unaryExpression.UnaryExpressionType = UnaryExpressionType.Positive;
                            }
                            break;
                        case 199:
                            token2 = this.LT(1);
                            this.match(199);
                            if (base.inputState.guessing == 0) {
                                unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                                TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token2);
                                unaryExpression.UnaryExpressionType = UnaryExpressionType.Negative;
                            }
                            break;
                        case 211:
                            token3 = this.LT(1);
                            this.match(211);
                            if (base.inputState.guessing == 0) {
                                unaryExpression = base.FragmentFactory.CreateFragment<UnaryExpression>();
                                TSql80ParserBaseInternal.UpdateTokenInfo(unaryExpression, token3);
                                unaryExpression.UnaryExpressionType = UnaryExpressionType.BitwiseNot;
                            }
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    scalarExpression = this.expressionUnary(expressionFlags);
                    if (base.inputState.guessing == 0) {
                        result = unaryExpression;
                        unaryExpression.Expression = scalarExpression;
                    }
                    break;
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 200:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    result = this.expressionPrimary(expressionFlags);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return result;
        }

        public PrimaryExpression expressionPrimary(ExpressionFlags expressionFlags) {
            PrimaryExpression primaryExpression = null;
            switch (this.LA(1)) {
                case 235:
                    this.odbcInitiator();
                    break;
                case 93:
                    primaryExpression = this.leftFunctionCall();
                    break;
                case 133:
                    primaryExpression = this.rightFunctionCall();
                    break;
                case 101:
                    primaryExpression = this.nullIfExpression(expressionFlags);
                    break;
                case 25:
                    primaryExpression = this.coalesceExpression(expressionFlags);
                    break;
                case 20:
                    primaryExpression = this.caseExpression(expressionFlags);
                    break;
                case 34:
                    primaryExpression = this.convertCall();
                    break;
                case 40:
                case 41:
                case 141:
                case 147:
                case 163:
                    primaryExpression = this.parameterlessCall();
                    break;
                case 191:
                    primaryExpression = this.paranthesisDisambiguatorForExpressions(expressionFlags);
                    break;
                default: {
                        if (this.LA(1) == 193 && this.LA(2) == 232 && this.LA(1) == 193 && base.NextTokenMatches("FN", 2)) {
                            primaryExpression = this.odbcFunctionCall();
                            break;
                        }
                        if (TSql80ParserInternal.tokenSet_83_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_84_.member(this.LA(2))) {
                            primaryExpression = this.literal();
                            break;
                        }
                        if (this.LA(1) == 232 && this.LA(2) == 191 && base.NextTokenMatches("CAST") && this.LA(2) == 191) {
                            primaryExpression = this.castCall();
                            break;
                        }
                        bool flag = false;
                        if (this.LA(1) == 232 && this.LA(2) == 191) {
                            int pos = this.mark();
                            flag = true;
                            base.inputState.guessing++;
                            try {
                                this.match(232);
                                this.match(191);
                            } catch (RecognitionException) {
                                flag = false;
                            }
                            this.rewind(pos);
                            base.inputState.guessing--;
                        }
                        if (flag) {
                            primaryExpression = this.identifierBuiltInFunctionCall();
                            break;
                        }
                        if ((this.LA(1) == 228 || this.LA(1) == 232 || this.LA(1) == 233) && this.LA(2) == 200) {
                            if ((this.LA(1) == 232 || this.LA(1) == 233) && this.LA(2) == 200 && this.LA(3) == 228) {
                                goto IL_02b4;
                            }
                            if (this.LA(1) == 228) {
                                goto IL_02b4;
                            }
                        }
                        if (TSql80ParserInternal.tokenSet_80_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_85_.member(this.LA(2))) {
                            primaryExpression = this.columnOrFunctionCall();
                            break;
                        }
                        throw new NoViableAltException(this.LT(1), this.getFilename());
                    }
                    IL_02b4:
                    primaryExpression = this.partitionFunctionCall();
                    break;
            }
            this.collationOpt(primaryExpression);
            return primaryExpression;
        }

        public CastCall castCall() {
            CastCall castCall = base.FragmentFactory.CreateFragment<CastCall>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(232);
            this.match(191);
            ScalarExpression parameter = this.expression();
            this.match(9);
            DataTypeReference dataType = this.scalarDataType();
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.Match(token, "CAST");
                TSql80ParserBaseInternal.UpdateTokenInfo(castCall, token);
                castCall.DataType = dataType;
                castCall.Parameter = parameter;
                TSql80ParserBaseInternal.UpdateTokenInfo(castCall, token2);
            }
            return castCall;
        }

        public FunctionCall identifierBuiltInFunctionCall() {
            FunctionCall functionCall = base.FragmentFactory.CreateFragment<FunctionCall>();
            IToken token = null;
            Identifier functionName = this.nonQuotedIdentifier();
            if (base.inputState.guessing == 0) {
                functionCall.FunctionName = functionName;
            }
            this.match(191);
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 192:
                case 193:
                case 195:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    this.identifierBuiltInFunctionCallDefaultParams(functionCall);
                    break;
                case 5:
                case 51:
                    this.identifierBuiltInFunctionCallUniqueRowFilter(functionCall);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(functionCall, token);
            }
            return functionCall;
        }

        public LeftFunctionCall leftFunctionCall() {
            LeftFunctionCall leftFunctionCall = base.FragmentFactory.CreateFragment<LeftFunctionCall>();
            IToken token = null;
            token = this.LT(1);
            this.match(93);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(leftFunctionCall, token);
            }
            this.reservedBuiltInFunctionCallParameters(leftFunctionCall, leftFunctionCall.Parameters);
            return leftFunctionCall;
        }

        public RightFunctionCall rightFunctionCall() {
            RightFunctionCall rightFunctionCall = base.FragmentFactory.CreateFragment<RightFunctionCall>();
            IToken token = null;
            token = this.LT(1);
            this.match(133);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(rightFunctionCall, token);
            }
            this.reservedBuiltInFunctionCallParameters(rightFunctionCall, rightFunctionCall.Parameters);
            return rightFunctionCall;
        }

        public PartitionFunctionCall partitionFunctionCall() {
            PartitionFunctionCall partitionFunctionCall = base.FragmentFactory.CreateFragment<PartitionFunctionCall>();
            IToken token = null;
            IToken token2 = null;
            Identifier databaseName;
            switch (this.LA(1)) {
                case 232:
                case 233:
                    databaseName = this.identifier();
                    if (base.inputState.guessing == 0) {
                        partitionFunctionCall.DatabaseName = databaseName;
                    }
                    this.match(200);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 228:
                    break;
            }
            token = this.LT(1);
            this.match(228);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(partitionFunctionCall, token);
            }
            this.match(200);
            databaseName = this.identifier();
            if (base.inputState.guessing == 0) {
                partitionFunctionCall.FunctionName = databaseName;
            }
            this.match(191);
            this.expressionList(partitionFunctionCall, partitionFunctionCall.Parameters);
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(partitionFunctionCall, token2);
            }
            return partitionFunctionCall;
        }

        public PrimaryExpression columnOrFunctionCall() {
            PrimaryExpression primaryExpression = null;
            MultiPartIdentifier multiPartIdentifier = null;
            ColumnReferenceExpression columnReferenceExpression = null;
            switch (this.LA(1)) {
                case 200:
                case 232:
                case 233:
                    multiPartIdentifier = this.multiPartIdentifier(-1);
                    if (this.LA(1) == 200) {
                        if (base.inputState.guessing == 0) {
                            columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
                        }
                        this.match(200);
                        this.specialColumn(columnReferenceExpression);
                        break;
                    }
                    if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_86_.member(this.LA(2))) {
                        primaryExpression = this.userFunctionCall(multiPartIdentifier);
                        break;
                    }
                    if (TSql80ParserInternal.tokenSet_84_.member(this.LA(1)) && TSql80ParserInternal.tokenSet_87_.member(this.LA(2))) {
                        break;
                    }
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 81:
                case 136:
                case 227:
                    if (base.inputState.guessing == 0) {
                        columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
                    }
                    this.specialColumn(columnReferenceExpression);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            if (base.inputState.guessing == 0 && (primaryExpression == null || primaryExpression is ColumnReferenceExpression)) {
                if (columnReferenceExpression == null) {
                    columnReferenceExpression = base.FragmentFactory.CreateFragment<ColumnReferenceExpression>();
                }
                columnReferenceExpression.MultiPartIdentifier = multiPartIdentifier;
                TSql80ParserBaseInternal.CheckSpecialColumn(columnReferenceExpression);
                TSql80ParserBaseInternal.CheckTableNameExistsForColumn(columnReferenceExpression, false);
                primaryExpression = columnReferenceExpression;
            }
            return primaryExpression;
        }

        public NullIfExpression nullIfExpression(ExpressionFlags expressionFlags) {
            NullIfExpression nullIfExpression = base.FragmentFactory.CreateFragment<NullIfExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(101);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(nullIfExpression, token);
            }
            this.match(191);
            ScalarExpression firstExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                nullIfExpression.FirstExpression = firstExpression;
            }
            this.match(198);
            firstExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                nullIfExpression.SecondExpression = firstExpression;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(nullIfExpression, token2);
            }
            return nullIfExpression;
        }

        public CoalesceExpression coalesceExpression(ExpressionFlags expressionFlags) {
            CoalesceExpression coalesceExpression = base.FragmentFactory.CreateFragment<CoalesceExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(25);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(coalesceExpression, token);
            }
            this.match(191);
            ScalarExpression item = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(coalesceExpression, coalesceExpression.Expressions, item);
            }
            int num = 0;
            while (true) {
                if (this.LA(1) != 198) {
                    break;
                }
                this.match(198);
                item = this.expressionWithFlags(expressionFlags);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(coalesceExpression, coalesceExpression.Expressions, item);
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(coalesceExpression, token2);
            }
            return coalesceExpression;
        }

        public CaseExpression caseExpression(ExpressionFlags expressionFlags) {
            IToken token = null;
            IToken token2 = null;
            ScalarExpression scalarExpression = null;
            token = this.LT(1);
            this.match(20);
            CaseExpression caseExpression;
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    scalarExpression = this.expressionWithFlags(expressionFlags);
                    caseExpression = this.simpleCaseExpression(scalarExpression, expressionFlags);
                    break;
                case 168:
                    caseExpression = this.searchedCaseExpression(expressionFlags);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            switch (this.LA(1)) {
                case 55:
                    this.match(55);
                    scalarExpression = this.expressionWithFlags(expressionFlags);
                    if (base.inputState.guessing == 0) {
                        caseExpression.ElseExpression = scalarExpression;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 56:
                    break;
            }
            token2 = this.LT(1);
            this.match(56);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(caseExpression, token);
                TSql80ParserBaseInternal.UpdateTokenInfo(caseExpression, token2);
            }
            return caseExpression;
        }

        public ConvertCall convertCall() {
            ConvertCall convertCall = base.FragmentFactory.CreateFragment<ConvertCall>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(34);
            this.match(191);
            DataTypeReference dataType = this.scalarDataType();
            this.match(198);
            ScalarExpression parameter = this.expression();
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(convertCall, token);
                convertCall.DataType = dataType;
                convertCall.Parameter = parameter;
            }
            switch (this.LA(1)) {
                case 198:
                    this.match(198);
                    parameter = this.expression();
                    if (base.inputState.guessing == 0) {
                        convertCall.Style = parameter;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(convertCall, token2);
            }
            return convertCall;
        }

        public ParameterlessCall parameterlessCall() {
            ParameterlessCall parameterlessCall = base.FragmentFactory.CreateFragment<ParameterlessCall>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            switch (this.LA(1)) {
                case 163:
                    token = this.LT(1);
                    this.match(163);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(parameterlessCall, token);
                        parameterlessCall.ParameterlessCallType = ParameterlessCallType.User;
                    }
                    break;
                case 41:
                    token2 = this.LT(1);
                    this.match(41);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(parameterlessCall, token2);
                        parameterlessCall.ParameterlessCallType = ParameterlessCallType.CurrentUser;
                    }
                    break;
                case 141:
                    token3 = this.LT(1);
                    this.match(141);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(parameterlessCall, token3);
                        parameterlessCall.ParameterlessCallType = ParameterlessCallType.SessionUser;
                    }
                    break;
                case 147:
                    token4 = this.LT(1);
                    this.match(147);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(parameterlessCall, token4);
                        parameterlessCall.ParameterlessCallType = ParameterlessCallType.SystemUser;
                    }
                    break;
                case 40:
                    token5 = this.LT(1);
                    this.match(40);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(parameterlessCall, token5);
                        parameterlessCall.ParameterlessCallType = ParameterlessCallType.CurrentTimestamp;
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return parameterlessCall;
        }

        public PrimaryExpression paranthesisDisambiguatorForExpressions(ExpressionFlags expressionFlags) {
            PrimaryExpression primaryExpression = null;
            if (this.LA(1) == 191 && (this.LA(2) == 140 || this.LA(2) == 191) && base.IsNextRuleSelectParenthesis()) {
                return this.subquery(expressionFlags);
            }
            if (this.LA(1) == 191 && TSql80ParserInternal.tokenSet_16_.member(this.LA(2))) {
                return this.expressionParenthesis(expressionFlags);
            }
            throw new NoViableAltException(this.LT(1), this.getFilename());
        }

        public ParenthesisExpression expressionParenthesis(ExpressionFlags expressionFlags) {
            ParenthesisExpression parenthesisExpression = base.FragmentFactory.CreateFragment<ParenthesisExpression>();
            IToken token = null;
            IToken token2 = null;
            token = this.LT(1);
            this.match(191);
            ScalarExpression expression = this.expressionWithFlags(expressionFlags);
            token2 = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(parenthesisExpression, token);
                parenthesisExpression.Expression = expression;
                TSql80ParserBaseInternal.UpdateTokenInfo(parenthesisExpression, token2);
            }
            return parenthesisExpression;
        }

        public FunctionCall basicFunctionCall() {
            FunctionCall functionCall = base.FragmentFactory.CreateFragment<FunctionCall>();
            Identifier functionName = this.identifier();
            if (base.inputState.guessing == 0) {
                functionCall.FunctionName = functionName;
            }
            this.parenthesizedOptExpressionWithDefaultList(functionCall, functionCall.Parameters);
            return functionCall;
        }

        public void identifierBuiltInFunctionCallDefaultParams(FunctionCall vParent) {
            switch (this.LA(1)) {
                case 192:
                    break;
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    this.expressionList(vParent, vParent.Parameters);
                    break;
                case 195: {
                        ColumnReferenceExpression item = this.starColumnReferenceExpression();
                        if (base.inputState.guessing == 0) {
                            TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public void identifierBuiltInFunctionCallUniqueRowFilter(FunctionCall vParent) {
            UniqueRowFilter uniqueRowFilter = this.uniqueRowFilter();
            ScalarExpression item = this.expression();
            if (base.inputState.guessing == 0) {
                vParent.UniqueRowFilter = uniqueRowFilter;
                TSql80ParserBaseInternal.AddAndUpdateTokenInfo(vParent, vParent.Parameters, item);
            }
        }

        public void reservedBuiltInFunctionCallParameters(TSqlFragment vParent, IList<ScalarExpression> parameters) {
            IToken token = null;
            this.match(191);
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    this.expressionList(vParent, parameters);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
                case 192:
                    break;
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(vParent, token);
            }
        }

        public SimpleWhenClause simpleWhenClause(ExpressionFlags expressionFlags) {
            SimpleWhenClause simpleWhenClause = base.FragmentFactory.CreateFragment<SimpleWhenClause>();
            IToken token = null;
            ScalarExpression scalarExpression = null;
            token = this.LT(1);
            this.match(168);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(simpleWhenClause, token);
            }
            scalarExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                simpleWhenClause.WhenExpression = scalarExpression;
            }
            this.match(150);
            scalarExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                simpleWhenClause.ThenExpression = scalarExpression;
            }
            return simpleWhenClause;
        }

        public SearchedWhenClause searchedWhenClause(ExpressionFlags expressionFlags) {
            SearchedWhenClause searchedWhenClause = base.FragmentFactory.CreateFragment<SearchedWhenClause>();
            IToken token = null;
            BooleanExpression booleanExpression = null;
            ScalarExpression scalarExpression = null;
            token = this.LT(1);
            this.match(168);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(searchedWhenClause, token);
            }
            booleanExpression = this.booleanExpressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                searchedWhenClause.WhenExpression = booleanExpression;
            }
            this.match(150);
            scalarExpression = this.expressionWithFlags(expressionFlags);
            if (base.inputState.guessing == 0) {
                searchedWhenClause.ThenExpression = scalarExpression;
            }
            return searchedWhenClause;
        }

        public SimpleCaseExpression simpleCaseExpression(ScalarExpression inputExpression, ExpressionFlags expressionFlags) {
            SimpleCaseExpression simpleCaseExpression = base.FragmentFactory.CreateFragment<SimpleCaseExpression>();
            simpleCaseExpression.InputExpression = inputExpression;
            int num = 0;
            while (true) {
                if (this.LA(1) != 168) {
                    break;
                }
                SimpleWhenClause item = this.simpleWhenClause(expressionFlags);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(simpleCaseExpression, simpleCaseExpression.WhenClauses, item);
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return simpleCaseExpression;
        }

        public SearchedCaseExpression searchedCaseExpression(ExpressionFlags expressionFlags) {
            SearchedCaseExpression searchedCaseExpression = base.FragmentFactory.CreateFragment<SearchedCaseExpression>();
            int num = 0;
            while (true) {
                if (this.LA(1) != 168) {
                    break;
                }
                SearchedWhenClause item = this.searchedWhenClause(expressionFlags);
                if (base.inputState.guessing == 0) {
                    TSql80ParserBaseInternal.AddAndUpdateTokenInfo(searchedCaseExpression, searchedCaseExpression.WhenClauses, item);
                }
                num++;
            }
            if (num < 1) {
                throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return searchedCaseExpression;
        }

        public void specialColumn(ColumnReferenceExpression vResult) {
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            switch (this.LA(1)) {
                case 81:
                    token = this.LT(1);
                    this.match(81);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token);
                        vResult.ColumnType = ColumnType.IdentityCol;
                    }
                    break;
                case 136:
                    token2 = this.LT(1);
                    this.match(136);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token2);
                        vResult.ColumnType = ColumnType.RowGuidCol;
                    }
                    break;
                case 227:
                    token3 = this.LT(1);
                    this.match(227);
                    if (base.inputState.guessing == 0) {
                        TSql80ParserBaseInternal.UpdateTokenInfo(vResult, token3);
                        vResult.ColumnType = PseudoColumnHelper.Instance.ParseOption(token3, SqlVersionFlags.TSql80);
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
        }

        public FunctionCall userFunctionCall(MultiPartIdentifier vIdentifiers) {
            FunctionCall functionCall = base.FragmentFactory.CreateFragment<FunctionCall>();
            IToken token = null;
            this.match(191);
            switch (this.LA(1)) {
                case 20:
                case 25:
                case 34:
                case 40:
                case 41:
                case 47:
                case 81:
                case 93:
                case 100:
                case 101:
                case 133:
                case 136:
                case 141:
                case 147:
                case 163:
                case 191:
                case 192:
                case 193:
                case 197:
                case 199:
                case 200:
                case 211:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 227:
                case 228:
                case 230:
                case 231:
                case 232:
                case 233:
                case 234:
                case 235:
                    switch (this.LA(1)) {
                        case 20:
                        case 25:
                        case 34:
                        case 40:
                        case 41:
                        case 47:
                        case 81:
                        case 93:
                        case 100:
                        case 101:
                        case 133:
                        case 136:
                        case 141:
                        case 147:
                        case 163:
                        case 191:
                        case 193:
                        case 197:
                        case 199:
                        case 200:
                        case 211:
                        case 221:
                        case 222:
                        case 223:
                        case 224:
                        case 225:
                        case 227:
                        case 228:
                        case 230:
                        case 231:
                        case 232:
                        case 233:
                        case 234:
                        case 235:
                            this.expressionWithDefaultList(functionCall, functionCall.Parameters);
                            break;
                        default:
                            throw new NoViableAltException(this.LT(1), this.getFilename());
                        case 192:
                            break;
                    }
                    break;
                case 5:
                case 51:
                    this.identifierBuiltInFunctionCallUniqueRowFilter(functionCall);
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token = this.LT(1);
            this.match(192);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(functionCall, token);
                base.PutIdentifiersIntoFunctionCall(functionCall, vIdentifiers);
            }
            return functionCall;
        }

        public DiskStatementOption diskStatementOption() {
            DiskStatementOption diskStatementOption = base.FragmentFactory.CreateFragment<DiskStatementOption>();
            IToken token = null;
            token = this.LT(1);
            this.match(232);
            this.match(206);
            IdentifierOrValueExpression value = this.identifierOrValueExpression();
            if (base.inputState.guessing == 0) {
                diskStatementOption.OptionKind = DiskStatementOptionsHelper.Instance.ParseOption(token);
                diskStatementOption.Value = value;
            }
            return diskStatementOption;
        }

        public IdentifierOrValueExpression identifierOrValueExpression() {
            IdentifierOrValueExpression identifierOrValueExpression = base.FragmentFactory.CreateFragment<IdentifierOrValueExpression>();
            switch (this.LA(1)) {
                case 232:
                case 233: {
                        Identifier identifier = this.identifier();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.Identifier = identifier;
                        }
                        break;
                    }
                case 100:
                case 193:
                case 221:
                case 222:
                case 223:
                case 224:
                case 225:
                case 230:
                case 231:
                case 234: {
                        ValueExpression valueExpression = this.literal();
                        if (base.inputState.guessing == 0) {
                            identifierOrValueExpression.ValueExpression = valueExpression;
                        }
                        break;
                    }
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            return identifierOrValueExpression;
        }

        public ValueExpression globalVariableOrVariableReference() {
            ValueExpression valueExpression = null;
            IToken token = null;
            token = this.LT(1);
            this.match(234);
            if (base.inputState.guessing == 0) {
                if (token.getText().StartsWith("@@", StringComparison.Ordinal)) {
                    GlobalVariableExpression globalVariableExpression = base.FragmentFactory.CreateFragment<GlobalVariableExpression>();
                    globalVariableExpression.Name = token.getText();
                    valueExpression = globalVariableExpression;
                } else {
                    VariableReference variableReference = base.FragmentFactory.CreateFragment<VariableReference>();
                    variableReference.Name = token.getText();
                    valueExpression = variableReference;
                }
                TSql80ParserBaseInternal.UpdateTokenInfo(valueExpression, token);
            }
            return valueExpression;
        }

        public MoneyLiteral moneyLiteral() {
            MoneyLiteral moneyLiteral = base.FragmentFactory.CreateFragment<MoneyLiteral>();
            IToken token = null;
            token = this.LT(1);
            this.match(225);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(moneyLiteral, token);
                moneyLiteral.Value = token.getText();
            }
            return moneyLiteral;
        }

        public OdbcLiteral odbcLiteral() {
            OdbcLiteral odbcLiteral = base.FragmentFactory.CreateFragment<OdbcLiteral>();
            IToken token = null;
            IToken token2 = null;
            IToken token3 = null;
            IToken token4 = null;
            IToken token5 = null;
            token = this.LT(1);
            this.match(193);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(odbcLiteral, token);
            }
            token2 = this.LT(1);
            this.match(232);
            switch (this.LA(1)) {
                case 230:
                    token3 = this.LT(1);
                    this.match(230);
                    if (base.inputState.guessing == 0) {
                        odbcLiteral.OdbcLiteralType = TSql80ParserBaseInternal.ParseOdbcLiteralType(token2);
                        TSql80ParserBaseInternal.UpdateTokenInfo(odbcLiteral, token3);
                        odbcLiteral.Value = TSql80ParserBaseInternal.DecodeAsciiStringLiteral(token3.getText());
                    }
                    break;
                case 231:
                    token4 = this.LT(1);
                    this.match(231);
                    if (base.inputState.guessing == 0) {
                        odbcLiteral.OdbcLiteralType = TSql80ParserBaseInternal.ParseOdbcLiteralType(token2);
                        odbcLiteral.IsNational = true;
                        TSql80ParserBaseInternal.UpdateTokenInfo(odbcLiteral, token4);
                        odbcLiteral.Value = TSql80ParserBaseInternal.DecodeUnicodeStringLiteral(token4.getText());
                    }
                    break;
                default:
                    throw new NoViableAltException(this.LT(1), this.getFilename());
            }
            token5 = this.LT(1);
            this.match(194);
            if (base.inputState.guessing == 0) {
                TSql80ParserBaseInternal.UpdateTokenInfo(odbcLiteral, token5);
            }
            return odbcLiteral;
        }

        private void initializeFactory() {
        }

        private static long[] mk_tokenSet_0_() {
            long[] array = new long[8]
            {
                3585973655481528898L,
                -1675334557835686887L,
                -9209513072622709414L,
                6322594533441L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_1_() {
            long[] array = new long[8]
            {
                9214359473050810082L,
                -1454733885903487047L,
                -1139059068170799109L,
                17437434049535L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_2_() {
            long[] array = new long[8]
            {
                3585973655481528898L,
                -1675334557835686887L,
                -9209513210061662886L,
                6322594533441L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_3_() {
            long[] array = new long[8]
            {
                3477746525793333312L,
                7530022977430359041L,
                -9209522008302168998L,
                268435456L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_4_() {
            return new long[6]
            {
                140737488355328L,
                216172782113784320L,
                275012127232L,
                0L,
                0L,
                0L
            };
        }

        private static long[] mk_tokenSet_5_() {
            long[] array = new long[8]
            {
                3477746525793333314L,
                7530022977430359041L,
                -9209522008302168998L,
                7696984047872L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_6_() {
            long[] array = new long[8]
            {
                8240455983232626786L,
                -1474861547081199967L,
                -9209512900031547398L,
                35029619577258L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_7_() {
            return new long[6]
            {
                16777216L,
                17180917760L,
                2147483648L,
                0L,
                0L,
                0L
            };
        }

        private static long[] mk_tokenSet_8_() {
            long[] array = new long[8]
            {
                0L,
                2313372481617920L,
                0L,
                7696581394688L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_9_() {
            long[] array = new long[8]
            {
                0L,
                61572651155456L,
                0L,
                7696581394688L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_10_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530022977430359041L,
                -9209522008302168998L,
                402657280L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_11_() {
            long[] array = new long[8]
            {
                8348542374289518690L,
                -1474861547081199967L,
                -9209512900031547398L,
                17437433532842L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_12_() {
            long[] array = new long[8]
            {
                9011597301252608L,
                4294967296L,
                0L,
                3298534883328L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_13_() {
            long[] array = new long[8]
            {
                0L,
                618475290624L,
                0L,
                8537858113666L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_14_() {
            long[] array = new long[8]
            {
                8796093022208L,
                0L,
                100663296L,
                1099511627776L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_15_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530022977430359041L,
                -9209513212209146790L,
                402657280L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_16_() {
            long[] array = new long[8]
            {
                3315749355520L,
                206695432192L,
                -9223372002494504672L,
                17437030875554L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_17_() {
            long[] array = new long[8]
            {
                3585836232666689602L,
                7530023184125791233L,
                -2291991846789188230L,
                17437433926570L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_18_() {
            long[] array = new long[8]
            {
                0L,
                68719476736L,
                0L,
                8537858113667L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_19_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530022977430359041L,
                -9209513212209146790L,
                402657344L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_20_() {
            long[] array = new long[8]
            {
                3585832916917334082L,
                7530022977430359049L,
                -9209522008302168998L,
                402657280L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_21_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530022977430359041L,
                -9209522008302168998L,
                402657344L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_22_() {
            long[] array = new long[8]
            {
                9007199254740992L,
                4294967296L,
                0L,
                3298534883328L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_23_() {
            long[] array = new long[8]
            {
                0L,
                103079215104L,
                0L,
                65L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_24_() {
            long[] array = new long[8]
            {
                0L,
                68719476736L,
                0L,
                8537858113666L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_25_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 1111859658817L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_26_() {
            long[] array = new long[8]
            {
                8704L,
                0L,
                8L,
                64L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_27_() {
            return new long[6]
            {
                3459045988797251616L,
                -9223372036850581504L,
                4294971392L,
                0L,
                0L,
                0L
            };
        }

        private static long[] mk_tokenSet_28_() {
            long[] array = new long[8]
            {
                0L,
                2199023255552L,
                -9223372036854775808L,
                1099511627840L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_29_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530163714935491585L,
                -9209522008302168998L,
                402657280L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_30_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530022977447136257L,
                -9209522008302168998L,
                3298937540608L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_31_() {
            long[] array = new long[8]
            {
                0L,
                128L,
                0L,
                4398583382144L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_32_() {
            long[] array = new long[8]
            {
                4162293738409996354L,
                7531854764416711945L,
                -9209511012112149382L,
                402657349L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_33_() {
            long[] array = new long[8]
            {
                9214359614785058530L,
                -301742012686680071L,
                -1139059068170799110L,
                17437434051583L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_34_() {
            long[] array = new long[8]
            {
                576460786663161858L,
                8390656L,
                8797166764032L,
                134217729L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_35_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 3298534883592L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_36_() {
            long[] array = new long[8]
            {
                576460786663161858L,
                562949961824392L,
                10996190019584L,
                3298669101377L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_37_() {
            long[] array = new long[8]
            {
                3315749355520L,
                206695464960L,
                -9223372002494504672L,
                17437030875554L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_38_() {
            long[] array = new long[8]
            {
                576464102479626754L,
                563156657256584L,
                -2305830879151771360L,
                17437165503467L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_39_() {
            long[] array = new long[8]
            {
                4162293669690519618L,
                7530726664880532489L,
                -9209513211135404966L,
                402657281L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_40_() {
            long[] array = new long[8]
            {
                9214359473051137762L,
                -301812381430857799L,
                -1139059068170799110L,
                17437434049535L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_41_() {
            long[] array = new long[8]
            {
                4162293669690519618L,
                7530726664897313929L,
                -9209519808205171622L,
                3298937540929L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_42_() {
            long[] array = new long[8]
            {
                4162296985506984514L,
                7530726871592746121L,
                -2291989646692190854L,
                17437433943019L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_43_() {
            long[] array = new long[8]
            {
                4162296985506984514L,
                7530726871592746121L,
                -2291980850599168646L,
                17437433926635L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_44_() {
            return new long[6]
            {
                68719476736L,
                1125900512919808L,
                32L,
                0L,
                0L,
                0L
            };
        }

        private static long[] mk_tokenSet_45_() {
            long[] array = new long[8]
            {
                4294967296L,
                131941395333184L,
                -9223372036854775808L,
                7696581396736L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_46_() {
            long[] array = new long[8]
            {
                4162293738409996866L,
                7531854764416728329L,
                -9209511012112149382L,
                3298937540933L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_47_() {
            long[] array = new long[8]
            {
                68719477248L,
                1125900512936192L,
                -9223363240761749472L,
                3298534883584L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_48_() {
            long[] array = new long[8]
            {
                4162293738409996866L,
                7531854764416728329L,
                -9209511012112149382L,
                3298937540677L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_49_() {
            long[] array = new long[8]
            {
                9214359614785058530L,
                -301742012686663687L,
                -1139059068170799110L,
                17437434051583L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_50_() {
            long[] array = new long[8]
            {
                144053237710848L,
                206695432192L,
                -9223372002494504672L,
                17437030875555L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_51_() {
            long[] array = new long[8]
            {
                4611689336324227072L,
                241055170592L,
                -9223371997662666464L,
                17437030875554L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_52_() {
            return new long[6]
            {
                3458905251308896256L,
                0L,
                -9223371968135294976L,
                0L,
                0L,
                0L
            };
        }

        private static long[] mk_tokenSet_53_() {
            long[] array = new long[8]
            {
                2255115563040800L,
                9002788487168L,
                -9223371933758246624L,
                17437030875562L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_54_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 3298534899968L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_55_() {
            long[] array = new long[8]
            {
                3585836232666689602L,
                7530163921614146689L,
                -2291989647765932678L,
                17437433926634L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_56_() {
            long[] array = new long[8];
            for (int i = 0; i <= 1; i++) {
                array[i] = 0L;
            }
            array[2] = -9223372036854775808L;
            array[3] = 3298534883584L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_57_() {
            long[] array = new long[8]
            {
                3585973654338580546L,
                7530163714918714497L,
                -9209510944466414502L,
                3298937540864L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_58_() {
            long[] array = new long[8]
            {
                0L,
                1064960L,
                0L,
                1099511627840L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_59_() {
            long[] array = new long[8]
            {
                4162293738409996866L,
                7531854764417776905L,
                -9209511012112149382L,
                3298937540677L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_60_() {
            long[] array = new long[8]
            {
                4162293738409996354L,
                7531854764417776905L,
                -9209511012112149382L,
                1099914285125L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_61_() {
            long[] array = new long[8]
            {
                0L,
                1064960L,
                -9223372036854775808L,
                1099511627776L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_62_() {
            long[] array = new long[8]
            {
                4162293738409996866L,
                7531854764416711945L,
                -9209511012112149382L,
                3298937540677L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_63_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530163714918714369L,
                -9209522008302168998L,
                402657344L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_64_() {
            long[] array = new long[8]
            {
                0L,
                9570149275275264L,
                1073741824L,
                1099511627776L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_65_() {
            long[] array = new long[8]
            {
                0L,
                8796093022208L,
                0L,
                7696581394688L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_66_() {
            long[] array = new long[8]
            {
                3585973654338580546L,
                7530163783638191105L,
                -9209513212209146790L,
                26130446815618L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_67_() {
            long[] array = new long[8]
            {
                140737488355328L,
                68719476736L,
                0L,
                8537858113666L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_68_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530163714918714369L,
                -9209513212209146790L,
                1112262316097L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_69_() {
            long[] array = new long[8]
            {
                3585832916850225218L,
                7530163714918714369L,
                -9209513212209146790L,
                402657345L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_70_() {
            long[] array = new long[8]
            {
                140738564194304L,
                18014398509482000L,
                2147483648L,
                3298534883328L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_71_() {
            long[] array = new long[8]
            {
                3585973655414419522L,
                -1675332358812431343L,
                -9209513210061662886L,
                402657345L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_72_() {
            long[] array = new long[8]
            {
                8348542375365358178L,
                -1456844949414244683L,
                -9209512900031547398L,
                17437433532907L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_73_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 1610612896L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_74_() {
            long[] array = new long[8]
            {
                3585973655414419522L,
                -1675334557835686895L,
                -9209522006154685094L,
                402657345L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_75_() {
            long[] array = new long[8]
            {
                8348542375365358178L,
                -1456844949414244679L,
                -9209512900031547398L,
                17437433532907L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_76_() {
            long[] array = new long[8]
            {
                8348542375365358178L,
                -1456844949414244687L,
                -9209512900031547398L,
                17437433532907L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_77_() {
            long[] array = new long[8]
            {
                3585973655414419522L,
                -1675332358812431343L,
                -9209522006154685094L,
                402657345L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_78_() {
            long[] array = new long[8]
            {
                3315816480768L,
                242162991104L,
                -1152920370734943968L,
                17437031392186L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_79_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 3298534883585L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_80_() {
            long[] array = new long[8]
            {
                0L,
                131072L,
                256L,
                3332894621952L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_81_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 3298534883649L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_82_() {
            long[] array = new long[8];
            for (int i = 0; i <= 2; i++) {
                array[i] = 0L;
            }
            array[3] = 3298534883648L;
            for (int j = 4; j <= 7; j++) {
                array[j] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_83_() {
            long[] array = new long[8]
            {
                0L,
                68719476736L,
                0L,
                5239323230210L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_84_() {
            long[] array = new long[8]
            {
                4451790753099871938L,
                -1673221294748025447L,
                -1139059378200914566L,
                4123571778303L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_85_() {
            long[] array = new long[8]
            {
                4451790753099871938L,
                -1673221294748025447L,
                -1139059378200914566L,
                4123571778559L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_86_() {
            long[] array = new long[8]
            {
                2395853051396128L,
                206695432192L,
                -9223372002494504672L,
                17437030875555L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }

        private static long[] mk_tokenSet_87_() {
            long[] array = new long[8]
            {
                9223366814039799778L,
                -301742008257495047L,
                -1139058999451191302L,
                17437434051583L,
                0L,
                0L,
                0L,
                0L
            };
            for (int i = 4; i <= 7; i++) {
                array[i] = 0L;
            }
            return array;
        }
    }
}
