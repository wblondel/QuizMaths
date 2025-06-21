using System.ComponentModel;

namespace QuizMaths.UI;

public class InputForm : Form
{
    private Label promptLabel;
    private TextBox inputTextBox;
    private Button okButton;
    private Button cancelButton;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string PromptText
    {
        get => promptLabel.Text;
        set => promptLabel.Text = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string InputText
    {
        get => inputTextBox.Text;
        set => inputTextBox.Text = value;
    }

    public InputForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        promptLabel = new Label();
        inputTextBox = new TextBox();
        okButton = new Button();
        cancelButton = new Button();
        SuspendLayout();

        // promptLabel
        promptLabel.Location = new Point(12, 15);
        promptLabel.Size = new Size(360, 60);
        promptLabel.Text = "Prompt";

        // inputTextBox
        inputTextBox.Location = new Point(12, 85);
        inputTextBox.Size = new Size(360, 23);

        // okButton
        okButton.DialogResult = DialogResult.OK;
        okButton.Location = new Point(216, 125);
        okButton.Size = new Size(75, 23);
        okButton.Text = "OK";
        okButton.UseVisualStyleBackColor = true;

        // cancelButton
        cancelButton.DialogResult = DialogResult.Cancel;
        cancelButton.Location = new Point(297, 125);
        cancelButton.Size = new Size(75, 23);
        cancelButton.Text = "Cancel";
        cancelButton.UseVisualStyleBackColor = true;

        // InputForm
        AcceptButton = okButton;
        CancelButton = cancelButton;
        ClientSize = new Size(384, 161);
        Controls.Add(promptLabel);
        Controls.Add(inputTextBox);
        Controls.Add(okButton);
        Controls.Add(cancelButton);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        ResumeLayout(false);
    }
}
