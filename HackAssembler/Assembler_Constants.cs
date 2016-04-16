namespace HackAssembler
{
    public enum Token_Type
    {
        COMMENT = 0,
        EMPTYLINE = 1,
        CONSTANT = 2,
        CTYPE = 3,
        LABEL = 4,
        OTHER
    }
    class Assembler_Constants
    {
        public static readonly string LINE_COMMENT = @"//";
        public static readonly string CONSTANT = "@";
    }
}