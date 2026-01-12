using System;
using System.Collections.Generic;

namespace Szamonkeres_BerziDaniel.Models;

public partial class FilmType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
