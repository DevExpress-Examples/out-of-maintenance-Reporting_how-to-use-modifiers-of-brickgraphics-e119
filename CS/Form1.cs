using System;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraPrinting;
// ...

namespace UseModifiers {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            BrickGraphics graph = printingSystem1.Graph;

            // Start the report generation.
            printingSystem1.Begin();

            // Set the modifier - specify the page area.
            graph.Modifier = BrickModifier.MarginalHeader;

            string format = "Page {0} of {1}";
            graph.Font = graph.DefaultFont;
            graph.BackColor = Color.Transparent;
            RectangleF r = new RectangleF(0, 0, 0, ((Font)graph.Font).Height);

            // Create a brick.
            PageInfoBrick brick = graph.DrawPageInfo(PageInfo.NumberOfTotal,
                format, Color.Black, r, BorderSide.None);

            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;

            // Create another brick with different alignment.
            brick = graph.DrawPageInfo(PageInfo.DateTime, "{0:MMMM dd}",
                Color.Black, r, BorderSide.None);



            // Change the page area - set the modifier.
            printingSystem1.Graph.Modifier = BrickModifier.DetailHeader;

            graph.BackColor = Color.Silver;

            // Create a brick.
            printingSystem1.Graph.DrawString("Report Items", Color.Black,
                new RectangleF(0, 0, 200, 20), BorderSide.All);



            // Change the page area - set the modifier.
            printingSystem1.Graph.Modifier = BrickModifier.Detail;

            graph.BackColor = Color.White;

            // Create bricks.
            for(int i = 0; i < 100; i++)
                printingSystem1.Graph.DrawString("Item N" + Convert.ToString(i + 1),
                    Color.Black, new RectangleF(0, 20 * i, 200, 20), BorderSide.All);


            printingSystem1.End();
            printingSystem1.PreviewFormEx.Show();
        }

    }
}