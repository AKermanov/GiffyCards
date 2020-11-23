namespace GiffyCards.Data.Models
{
    using System.Drawing;

    using GiffyCards.Data.Common.Models;

    public class Setting:BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
