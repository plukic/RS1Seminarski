namespace DataLayer.Models
{
    public class WorksheetTool
    {
        public int WorksheetId { get; set; }
        public Worksheet Worksheet { get; set; }

        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}
