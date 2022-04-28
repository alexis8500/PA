using System;
using System.Collections.Generic;

namespace Banco2.Models
{
  public partial class Cuenta
  {
    public int Id { get; set; }
    public int? NCuentaGerente { get; set; }
    public int? NCuentaEmpleado { get; set; }
    public long? NCuentaUsuario { get; set; }
    public int Tipo { get; set; }

    public virtual Empleado? NCuentaEmpleadoNavigation { get; set; }
    public virtual Gerente? NCuentaGerenteNavigation { get; set; }
    public virtual Usuario? NCuentaUsuarioNavigation { get; set; }
  }
}