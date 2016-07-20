using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipes.Core.Model
{
    public interface ITitleDomainObject : IDomainObject
    {
        string Title { get; set; }
    }
}
