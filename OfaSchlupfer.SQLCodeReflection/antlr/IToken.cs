#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    internal interface IToken {
        int Type {
            get;
            set;
        }

        int getColumn();

        void setColumn(int c);

        int getLine();

        void setLine(int l);

        string getFilename();

        void setFilename(string name);

        string getText();

        void setText(string t);
    }
}
