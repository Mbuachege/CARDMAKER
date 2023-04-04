
namespace CARDMAKER
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.importDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importedData = new CARDMAKER.ImportedData();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.designsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cardDesigns = new CARDMAKER.CardDesigns();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblTotalCards = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblCardDesigns = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblImported = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.importDataTableAdapter = new CARDMAKER.ImportedDataTableAdapters.ImportDataTableAdapter();
            this.designsTableAdapter = new CARDMAKER.CardDesignsTableAdapters.DesignsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDesigns)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.importDataBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 172);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Name";
            series1.XValueMember = "Form";
            series1.YValueMembers = "RegNo";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Legend = "Legend1";
            series2.Name = "RegNo";
            series2.XValueMember = "Form";
            series2.YValueMembers = "Name";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Form";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(423, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // importDataBindingSource
            // 
            this.importDataBindingSource.DataMember = "ImportData";
            this.importDataBindingSource.DataSource = this.importedData;
            // 
            // importedData
            // 
            this.importedData.DataSetName = "ImportedData";
            this.importedData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.DataSource = this.designsBindingSource;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(441, 172);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series4.Legend = "Legend1";
            series4.Name = "Institution";
            series4.XValueMember = "DesignName";
            series4.YValueMembers = "Id";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "DesignName";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Size = new System.Drawing.Size(429, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // designsBindingSource
            // 
            this.designsBindingSource.DataMember = "Designs";
            this.designsBindingSource.DataSource = this.cardDesigns;
            // 
            // cardDesigns
            // 
            this.cardDesigns.DataSetName = "CardDesigns";
            this.cardDesigns.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblTotalCards);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(45, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 103);
            this.panel1.TabIndex = 2;
            // 
            // LblTotalCards
            // 
            this.LblTotalCards.AutoSize = true;
            this.LblTotalCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTotalCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalCards.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblTotalCards.Location = new System.Drawing.Point(126, 51);
            this.LblTotalCards.Name = "LblTotalCards";
            this.LblTotalCards.Size = new System.Drawing.Size(59, 41);
            this.LblTotalCards.TabIndex = 1;
            this.LblTotalCards.Text = "40";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "GENERATED\r\nCARDS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblCardDesigns);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(304, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 103);
            this.panel2.TabIndex = 3;
            // 
            // LblCardDesigns
            // 
            this.LblCardDesigns.AutoSize = true;
            this.LblCardDesigns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblCardDesigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCardDesigns.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblCardDesigns.Location = new System.Drawing.Point(154, 51);
            this.LblCardDesigns.Name = "LblCardDesigns";
            this.LblCardDesigns.Size = new System.Drawing.Size(59, 41);
            this.LblCardDesigns.TabIndex = 2;
            this.LblCardDesigns.Text = "40";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 58);
            this.label2.TabIndex = 1;
            this.label2.Text = "CARD\r\nDESIGNS";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LblImported);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(607, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 103);
            this.panel3.TabIndex = 4;
            // 
            // LblImported
            // 
            this.LblImported.AutoSize = true;
            this.LblImported.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblImported.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblImported.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblImported.Location = new System.Drawing.Point(145, 51);
            this.LblImported.Name = "LblImported";
            this.LblImported.Size = new System.Drawing.Size(59, 41);
            this.LblImported.TabIndex = 3;
            this.LblImported.Text = "40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 58);
            this.label3.TabIndex = 2;
            this.label3.Text = "IMPORTED\r\nFILES";
            // 
            // importDataTableAdapter
            // 
            this.importDataTableAdapter.ClearBeforeFill = true;
            // 
            // designsTableAdapter
            // 
            this.designsTableAdapter.ClearBeforeFill = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(875, 532);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDesigns)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label LblTotalCards;
        private System.Windows.Forms.Label LblCardDesigns;
        private System.Windows.Forms.Label LblImported;
        private ImportedData importedData;
        private System.Windows.Forms.BindingSource importDataBindingSource;
        private ImportedDataTableAdapters.ImportDataTableAdapter importDataTableAdapter;
        private CardDesigns cardDesigns;
        private System.Windows.Forms.BindingSource designsBindingSource;
        private CardDesignsTableAdapters.DesignsTableAdapter designsTableAdapter;
    }
}