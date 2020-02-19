using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamConference.WebAPI.Models
{
    public class ChannelCategory
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public Guid UserId { get; set; }

        public User CreatedBy { get; set; }
    }
}
