using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Integrador
{
    public partial class Empleado
    {
        public Empleado()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<Prestamo> Prestamos { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }

        public object GetAll()
        {
            using (var db = new bancoContext())
            {
                return db.Empleados.ToList();
            }
        }

        public object Get(int id)
        {
            using (var db = new bancoContext())
            {
                var empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return null;
                }

                return empleado;
            }
        }

        // public object login(int user, string pass)
        // {
        //     using (var db = new bancoContext())
        //     {
        //         var empleado = db.Empleados.Where(u => u.Id == user && u.Password == pass).FirstOrDefault();

        //         if (empleado == null)
        //         {
        //             return new Exception("Usuario o contraseña inválidos");
        //         }

        //         return empleado;
        //     }
        // }

        public class EmpleadoCreate
        {
            [Required]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
            public string PrimerNombre { get; set; } = null!;
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
            public string? SegundoNombre { get; set; }
            [Required]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
            public string PrimerApellido { get; set; } = null!;
            [Required]
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
            public string SegundoApellido { get; set; } = null!;
            [Required]
            [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Solo permitido formato YYYY-MM-DD")]
            public DateTime FechaNacimiento { get; set; }

            public object Create(string Pn, string? Sn, string Pa, string Sa, DateTime nacimiento, string pass)
            {
                using (var db = new bancoContext())
                {
                    if (Pn == null || Pa == null || Sa == null || nacimiento == null || pass == null)
                    {
                        return new Exception("Algun dato es nulo");
                    }

                    bool flag = Pn.Any(char.IsDigit);
                    if (flag == true)
                    {
                        return new Exception("Los Nombres no pueden llevar numeros..");
                    }
                    flag = Pn.Any(char.IsSymbol);
                    if (flag == true)
                    {
                        return new Exception("Los Nombres no pueden llevar simbolos..");
                    }

                    if (Sn is not null)
                    {
                        flag = Sn.Any(char.IsDigit);
                        if (flag == true)
                        {
                            return new Exception("Los Nombres no pueden llevar numeros..");
                        }
                        flag = Sn.Any(char.IsSymbol);
                        if (flag == true)
                        {
                            return new Exception("Los Nombres no pueden llevar simbolos..");
                        }
                    }

                    flag = Pa.Any(char.IsDigit);
                    if (flag == true)
                    {
                        return new Exception("Los Apellidos no pueden llevar numeros..");
                    }
                    flag = Pa.Any(char.IsSymbol);
                    if (flag == true)
                    {
                        return new Exception("Los Apellidos no pueden llevar simbolos..");
                    }

                    flag = Sa.Any(char.IsDigit);
                    if (flag == true)
                    {
                        return new Exception("Los Apellidos no pueden llevar numeros..");
                    }
                    flag = Sa.Any(char.IsSymbol);
                    if (flag == true)
                    {
                        return new Exception("Los Apellidos no pueden llevar simbolos..");
                    }

                    var empleado = new Empleado();

                    empleado.PrimerNombre = Pn;
                    empleado.SegundoNombre = Sn;
                    empleado.PrimerApellido = Pa;
                    empleado.SegundoApellido = Sa;
                    empleado.Activo = true;
                    empleado.FechaNacimiento = nacimiento;
                    empleado.Password = pass;

                    db.Empleados.Add(empleado);
                    db.SaveChanges();

                    var cuenta = new Cuenta();
                    cuenta.NCuentaEmpleado = empleado.Id;
                    cuenta.Tipo = 2;
                    db.Cuentas.Add(cuenta);
                    db.SaveChanges();

                    return empleado;
                }
            }
        }
    }
}