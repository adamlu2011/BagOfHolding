using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagOfHolding.Models
{
    public class PlayerModel
    {
        [Required]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
    }
}
