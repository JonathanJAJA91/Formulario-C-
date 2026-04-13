using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Text.RegularExpressions;

namespace AppForm;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnEnviar_Click(object? sender, RoutedEventArgs e)
    {
        var nombre = this.FindControl<TextBox>("txtNombre").Text;
        var apellido = this.FindControl<TextBox>("txtApellido").Text;
        var edad = this.FindControl<TextBox>("txtEdad").Text;
        var correo = this.FindControl<TextBox>("txtCorreo").Text;
        var telefono = this.FindControl<TextBox>("txtTelefono").Text;
        var ciudad = this.FindControl<TextBox>("txtCiudad").Text;
        var direccion = this.FindControl<TextBox>("txtDireccion").Text;

        var resultado = this.FindControl<TextBlock>("txtResultado");

        // 🔴 VALIDACIONES

        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(edad) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(telefono) ||
            string.IsNullOrWhiteSpace(ciudad) ||
            string.IsNullOrWhiteSpace(direccion))
        {
            resultado.Foreground = Brushes.Red;
            resultado.Text = "⚠️ Todos los campos son obligatorios";
            return;
        }

        // Edad solo números
        if (!int.TryParse(edad, out int edadNum))
        {
            resultado.Foreground = Brushes.Red;
            resultado.Text = "⚠️ La edad debe ser un número válido";
            return;
        }

        // Teléfono solo números
        if (!long.TryParse(telefono, out _))
        {
            resultado.Foreground = Brushes.Red;
            resultado.Text = "⚠️ El teléfono debe contener solo números";
            return;
        }

        // Validar correo
        if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            resultado.Foreground = Brushes.Red;
            resultado.Text = "⚠️ Correo no válido";
            return;
        }

        // ✅ SI TODO ESTÁ BIEN

        resultado.Foreground = Brushes.Black;
        resultado.Inlines.Clear();

        resultado.Inlines.Add(new Run("Datos ingresados\n\n") { FontWeight = FontWeight.Bold });

        resultado.Inlines.Add(new Run("Nombre: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(nombre + "\n"));

        resultado.Inlines.Add(new Run("Apellido: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(apellido + "\n"));

        resultado.Inlines.Add(new Run("Edad: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(edad + "\n"));

        resultado.Inlines.Add(new Run("Correo: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(correo + "\n"));

        resultado.Inlines.Add(new Run("Teléfono: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(telefono + "\n"));

        resultado.Inlines.Add(new Run("Ciudad: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(ciudad + "\n"));

        resultado.Inlines.Add(new Run("Dirección: ") { FontWeight = FontWeight.Bold });
        resultado.Inlines.Add(new Run(direccion));
    }
}