using Decorator.Decorators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Player
    {
		[Required]
		public virtual string Name { get; set; }
		
		[StringLength(15)]
		public virtual string Description { get; set; }

		[Range(1, 15)]
		public virtual int HP { get; set; }
		public virtual int MP { get; set; }
		public virtual int ATK { get; set; }
		public virtual int DEF { get; set; }

        [ListSize(MaxItems =2, ErrorMessage ="Player can't carry more than 2 items in their Inventory")]
		public virtual List<string> Inventory { get; set; }
	}
}
