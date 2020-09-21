using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOT.ViewModels.Dto
{
    public class ModelDto : CommonDto
    {
        [Required(ErrorMessage = "Model name is required")]
        public string name { get; set; }

        public string thumbnailUrl { get; set; }

        public string objUrl { get; set; }

        public IList<string> placeTypes { get; set; }
    }
}
