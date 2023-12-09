namespace AutoCAD_Plugin_Bottle.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using AutoCAD_Plugin_Bottle.Model;

    /// <summary>
    /// Форма для задания параметров бутылки.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<BottleParameterType, string> _errors =
            new Dictionary<BottleParameterType, string>
            {
                { BottleParameterType.Length, "" },
                { BottleParameterType.Width, "" },
                { BottleParameterType.MainHeight, "" },
                { BottleParameterType.NeckHeight, "" },
                { BottleParameterType.NeckRadius, "" }
            };

        /// <summary>
        /// Словарь названий параметров.
        /// </summary>
        private readonly Dictionary<BottleParameterType, string> _parameterNames =
            new Dictionary<BottleParameterType, string>
            {
                { BottleParameterType.Length, "Длина" },
                { BottleParameterType.Width, "Ширина" },
                { BottleParameterType.MainHeight, "Высота основной части" },
                { BottleParameterType.NeckHeight, "Высота горлышка" },
                { BottleParameterType.NeckRadius, "Радиус горлышка" }
            };

        /// <summary>
        /// Словарь текстбоксов.
        /// </summary>
        private readonly Dictionary<BottleParameterType, TextBox> _parameterControls;

        /// <summary>
        /// Параметры модели.
        /// </summary>
        private readonly Parameters _parameters = new Parameters();

        /// <summary>
        /// Цвет элементов формы при отсутствии ошибок.
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Цвет элементов формы при наличии ошибок.
        /// </summary>
        private readonly Color _errorColor = Color.LightPink;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _parameterControls = new Dictionary<BottleParameterType, TextBox>
            {
                { BottleParameterType.Length, MainLengthTextBox },
                { BottleParameterType.Width, MainWidthTextBox },
                { BottleParameterType.MainHeight, MainHeightTextBox },
                { BottleParameterType.NeckHeight, NeckHeightTextBox },
                { BottleParameterType.NeckRadius, NeckRadiusTextBox }
            };
        }

        /// <summary>
        /// Очищает поля элементов на форме.
        /// </summary>
        private void ClearForm()
        {
            MainLengthTextBox.Text = "";
            MainWidthTextBox.Text = "";
            MainHeightTextBox.Text = "";
            NeckHeightTextBox.Text = "";
            NeckRadiusTextBox.Text = "";
        }

        /// <summary>
        /// Проверяет правильность введенных данных.
        /// </summary>
        /// <returns>true - ошибок нет, false - есть ошибки при введении данных.</returns>
        private bool CheckOnErrors()
        {
            string allErrors = "";

            foreach (var error in _errors)
            {
                if (error.Value != "")
                {
                    allErrors += error.Value;
                }
            }

            bool isEmpty = false;
            foreach (BottleParameterType parameterType
                in Enum.GetValues(typeof(BottleParameterType)))
            {
                if (_parameterControls[parameterType].Text == "")
                {
                    isEmpty = true;
                }
            }

            if (isEmpty)
            {
                allErrors += "• Введите все значения.\n";
            }

            if (allErrors != "")
            {
                MessageBox.Show(
                    allErrors,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Обработчик события изменения текста в текстбоксе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, EventArgs e)
        {
            var currentControl =
                _parameterControls.First(x => x.Value == sender);
            var currentParameter = currentControl.Key;

            try
            {
                if (_parameterControls[currentParameter].Text == "")
                {
                    _parameterControls[currentParameter].BackColor = _defaultColor;
                    _errors[currentParameter] = "";
                    return;
                }

                _parameters.SetValue(
                    currentParameter,
                    double.Parse(_parameterControls[currentParameter].Text));

                _errors[currentParameter] = "";
                _parameterControls[currentParameter].BackColor = _defaultColor;
            }
            catch (AggregateException aggregateException)
            {
                if (_errors[currentParameter] != "")
                {
                    _errors[currentParameter] = "";
                }

                foreach (ArgumentException exception in aggregateException.InnerExceptions)
                {
                    _errors[currentParameter] +=
                        $"• {_parameterNames[currentParameter]}: " + exception.Message;
                }

                _parameterControls[currentParameter].BackColor = _errorColor;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу клавиатуры.
        /// </summary>
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку создания модели бутылки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (!CheckOnErrors())
            {
                return;
            }

            Builder.BuildBottle(_parameters);
            ClearForm();
        }
    }
}
