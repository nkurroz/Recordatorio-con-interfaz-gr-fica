using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaz; // Usando el nombre de tu proyecto

// ---------------------------------------------------
// TU VENTANA PRINCIPAL (Normalita)
// ---------------------------------------------------
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        
        // Configuramos la ventana principal básica
        this.Text = "Friendly Reminder App";
        this.Size = new Size(300, 200);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Un botón simple para abrir el mensaje
        Button btnMostrar = new Button();
        btnMostrar.Text = "Abrir Recordatorio :)";
        btnMostrar.AutoSize = true;
        btnMostrar.Location = new Point(60, 70);
        
        // Evento para abrir la ventanita
        btnMostrar.Click += (sender, e) => 
        {
            using (DialogoRecordatorio dialog = new DialogoRecordatorio())
            {
                dialog.ShowDialog(this);
            }
        };
        
        this.Controls.Add(btnMostrar);
    }
}

// ---------------------------------------------------
// TU VENTANITA EMERGENTE (Estilo Mental OS)
// ---------------------------------------------------
public class DialogoRecordatorio : Form
{
    public DialogoRecordatorio()
    {
        // 1. Configuración de la ventanita
        this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde de diálogo clásico
        this.StartPosition = FormStartPosition.CenterParent; 
        this.ClientSize = new Size(300, 240); 
        this.BackColor = Color.FromArgb(255, 230, 240); // Fondo rosa pastel
        this.Text = "Friendly Reminder :D!"; 

        // 2. Imagen del gatito
        try 
        {
            PictureBox pbConejito = new PictureBox();
            pbConejito.Image = Image.FromFile(@"C:\Users\norae\OneDrive\Imágenes\interfaz\dibujo de gatito tierno.jpg"); // Tu imagen
            pbConejito.SizeMode = PictureBoxSizeMode.Zoom;
            pbConejito.Size = new Size(100, 100);
            pbConejito.Location = new Point((this.ClientSize.Width - pbConejito.Width) / 2, 10); 
            this.Controls.Add(pbConejito);
        }
        catch 
        {
            // Por si se te olvida poner la imagen, que no explote el programa
            Label lblErrorImg = new Label() { Text = "(Falta imagen)", Location = new Point(100, 50) };
            this.Controls.Add(lblErrorImg);
        }

        // 3. Texto principal
        Label lblMensaje = new Label();
        lblMensaje.Text = "¡Lo mejor está por llegar\nno te rindas! :D";
        lblMensaje.Font = new Font("Lucida Sans Typewriter", 8, FontStyle.Regular); // Letra amigable
        lblMensaje.ForeColor = Color.Black;
        lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
        lblMensaje.AutoSize = true;
        lblMensaje.Location = new Point(50, 120);
        this.Controls.Add(lblMensaje);

        // 4. Botón "I believe!"
        Button btnCreer = new Button();
        btnCreer.Text = "✨ Gracias :3 ✨";
        btnCreer.Font = new Font("Lucida Sans Typewriter", 10, FontStyle.Bold);
        btnCreer.BackColor = Color.FromArgb(255, 180, 220); // Botón rosa más oscuro
        btnCreer.FlatStyle = FlatStyle.Flat; 
        btnCreer.Size = new Size(180, 50);
        btnCreer.Location = new Point((this.ClientSize.Width - btnCreer.Width) / 2, 180);
        
        // Al hacer clic, se cierra esta ventanita
        btnCreer.Click += (s, e) => this.Close(); 
        
        this.Controls.Add(btnCreer);
    }
}