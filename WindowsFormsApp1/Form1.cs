using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TextBox txtInitialInvestment;
        TextBox txtMonthlyContribution;
        TextBox txtAnnualReturn;
        TextBox txtYears;
        Button btnCalculate;
        Label lblResult;
        Label lblInitialInvestment;
        Label lblMonthlyContribution;
        Label lblAnnualReturn;
        Label lblYears;

        public Form1()
        {
            InitializeComponent();
            InitializeFormComponents();
        }

        private void InitializeFormComponents()
        {
            // Label und TextBox für Anfangsinvestition
            lblInitialInvestment = new Label { Text = "Anfangsinvestition:", Location = new System.Drawing.Point(10, 20), Size = new System.Drawing.Size(160, 20) };
            txtInitialInvestment = new TextBox { Location = new System.Drawing.Point(180, 20), Width = 100 };
            Controls.Add(lblInitialInvestment);
            Controls.Add(txtInitialInvestment);

            // Label und TextBox für monatliche Einzahlung
            lblMonthlyContribution = new Label { Text = "Monatliche Einzahlung:", Location = new System.Drawing.Point(10, 50), Size = new System.Drawing.Size(160, 20) };
            txtMonthlyContribution = new TextBox { Location = new System.Drawing.Point(180, 50), Width = 100 };
            Controls.Add(lblMonthlyContribution);
            Controls.Add(txtMonthlyContribution);

            // Label und TextBox für durchschnittliche Rendite
            lblAnnualReturn = new Label { Text = "Durchschnittliche Rendite (%):", Location = new System.Drawing.Point(10, 80), Size = new System.Drawing.Size(160, 20) };
            txtAnnualReturn = new TextBox { Location = new System.Drawing.Point(180, 80), Width = 100 };
            Controls.Add(lblAnnualReturn);
            Controls.Add(txtAnnualReturn);

            // Label und TextBox für Anlagejahre
            lblYears = new Label { Text = "Anlagejahre:", Location = new System.Drawing.Point(10, 110), Size = new System.Drawing.Size(160, 20) };
            txtYears = new TextBox { Location = new System.Drawing.Point(180, 110), Width = 100 };
            Controls.Add(lblYears);
            Controls.Add(txtYears);

            // Button zum Berechnen
            btnCalculate = new Button { Text = "Berechnen", Location = new System.Drawing.Point(100, 140) };
            btnCalculate.Click += new EventHandler(BtnCalculate_Click);
            Controls.Add(btnCalculate);

            // Label für Ergebnisanzeige
            lblResult = new Label { Text = "Das Ergebnis wird hier angezeigt.", Location = new System.Drawing.Point(10, 170), Size = new System.Drawing.Size(300, 20) };
            Controls.Add(lblResult);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            // Berechnungslogik hier einfügen
            try
            {
                double initialInvestment = double.Parse(txtInitialInvestment.Text);
                double monthlyContribution = double.Parse(txtMonthlyContribution.Text);
                double annualReturn = double.Parse(txtAnnualReturn.Text);
                double years = double.Parse(txtYears.Text);

                double monthlyRate = annualReturn / 100 / 12;
                double futureValue = initialInvestment;

                for (int month = 1; month <= years * 12; month++)
                {
                    futureValue = (futureValue + monthlyContribution) * (1 + monthlyRate);
                }

                lblResult.Text = $"Erwartetes Endkapital nach {years} Jahren: {futureValue:C2}";
            }
            catch (FormatException)
            {
                lblResult.Text = "Bitte geben Sie gültige Zahlen ein.";
            }
        }
    }
}
