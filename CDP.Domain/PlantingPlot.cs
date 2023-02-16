using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Domain
{
    public class PlantingPlot
    {

        public int PlantingId { get; set; }

        public int PlotId { get; set; }

        public virtual Planting Plantio { get; set; }
        public virtual Plot Talhoes { get; set; }
    }
}
