using System.ComponentModel;

namespace QuizMaths.UI;

// Formulaire personnalisé pour la sélection
public class SelectionForm : Form
{
    private Label promptLabel;
    private ListBox optionsListBox;
    private Button okButton;
    private Button cancelButton;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string[] Options
    {
        set
        {
            optionsListBox.Items.Clear();
            optionsListBox.Items.AddRange(value);
            if (value.Length > 0) optionsListBox.SelectedIndex = 0;
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedIndex => optionsListBox.SelectedIndex;

    public SelectionForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        promptLabel = new Label();
        optionsListBox = new ListBox();
        okButton = new Button();
        cancelButton = new Button();
        SuspendLayout();

        // promptLabel
        promptLabel.Location = new Point(12, 15);
        promptLabel.Size = new Size(360, 23);
        promptLabel.Text = "Choose an option:";

        // optionsListBox
        optionsListBox.Location = new Point(12, 45);
        optionsListBox.Size = new Size(360, 95);

        // okButton
        okButton.DialogResult = DialogResult.OK;
        okButton.Location = new Point(216, 155);
        okButton.Size = new Size(75, 23);
        okButton.Text = "OK";
        okButton.UseVisualStyleBackColor = true;

        // cancelButton
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(297, 155);
        cancelButton.Size = new Size(75, 23);
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;

        // SelectionForm
        AcceptButton = okButton;
        CancelButton = cancelButton;
        ClientSize = new Size(384, 191);
        Controls.Add(promptLabel);
        Controls.Add(optionsListBox);
        Controls.Add(okButton);
        Controls.Add(cancelButton);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        ResumeLayout(false);
    }
}

