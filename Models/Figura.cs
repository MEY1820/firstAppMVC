using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstApp.Models
{ public class Figura
    
        {
[Key]
public int figuraId{get; set;}

[Required(ErrorMessage ="Nombre es requerido")]
[Display(Name ="Nombre")]
public string  nombre {get; set;}

[Required(ErrorMessage ="lados es requerido")]
[Display(Name ="lados")]
public string  lados {get; set;}

[Required(ErrorMessage ="angulo es requerido")]
[Display(Name ="angulo")]
public string angulo {get; set;}

//referencia para NombreFigura
[Required(ErrorMessage ="NombreFigura es requerido")]
[Display(Name ="NombreFigura")]
public int AutorFiguraID{get; set;}
public AutorFigura AutorFiguras {set; get;}

        }
}