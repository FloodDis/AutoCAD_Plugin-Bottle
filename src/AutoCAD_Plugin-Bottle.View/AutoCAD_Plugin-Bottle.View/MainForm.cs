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
        /// Словарь исключений.
        /// </summary>
        private readonly Dictionary<BottleParameterType, List<ArgumentException>> _exceptionsDictionary =
            new Dictionary<BottleParameterType, List<ArgumentException>>
            {
                { BottleParameterType.Length, new List<ArgumentException>() },
                { BottleParameterType.Width, new List<ArgumentException>() },
                { BottleParameterType.MainHeight, new List<ArgumentException>() },
                { BottleParameterType.NeckHeight, new List<ArgumentException>() },
                { BottleParameterType.NeckRadius, new List<ArgumentException>() }
            };

        /// <summary>
        /// Словарь текстбоксов.
        /// </summary>
        private readonly Dictionary<BottleParameterType, TextBox> _parameterControls =
            new Dictionary<BottleParameterType, TextBox>
            {
                { BottleParameterType.Length, null },
                { BottleParameterType.Width, null },
                { BottleParameterType.MainHeight, null },
                { BottleParameterType.NeckHeight, null },
                { BottleParameterType.NeckRadius, null }
            };

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

            _parameterControls[BottleParameterType.Length] = LengthTextBox;
            _parameterControls[BottleParameterType.Width] = WidthTextBox;
            _parameterControls[BottleParameterType.MainHeight] = MainHeightTextBox;
            _parameterControls[BottleParameterType.NeckHeight] = NeckHeightTextBox;
            _parameterControls[BottleParameterType.NeckRadius] = NeckRadiusTextBox;
        }

        /// <summary>
        /// Очищает поля элементов на форме.
        /// </summary>
        private void ClearForm()
        {
            LengthTextBox.Text = "";
            WidthTextBox.Text = "";
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
        /// Проверяет тип текстбокса.
        /// </summary>
        /// <param name="textBox">Текстбокс.</param>
        /// <returns>Тип параметра.</returns>
        private BottleParameterType CheckTextBoxType(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "LengthTextBox":
                {
                    return BottleParameterType.Length;
                }

                case "WidthTextBox":
                {
                    return BottleParameterType.Width;
                }

                case "MainHeightTextBox":
                {
                    return BottleParameterType.MainHeight;
                }

                case "NeckHeightTextBox":
                {
                    return BottleParameterType.NeckHeight;
                }

                case "RadiusTextBox":
                {
                    return BottleParameterType.NeckRadius;
                }

                default:
                    return BottleParameterType.NeckRadius;
            }
        }

        /// <summary>
        /// Обработчик события изменения текста в текстбоксе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, EventArgs e)
        {
            BottleParameterType currentParameter = CheckTextBoxType((TextBox)sender);

            try
            {
                if (_parameterControls[currentParameter].Text == "")
                {
                    _parameterControls[currentParameter].BackColor = _defaultColor;
                    _exceptionsDictionary[currentParameter].Clear();
                    _errors[currentParameter] = "";
                    return;
                }

                try
                {
                    _parameters.ParameterDictionary[currentParameter].Value =
                        double.Parse(_parameterControls[currentParameter].Text);
                }
                catch (ArgumentException exception)
                {
                    _exceptionsDictionary[currentParameter].Add(exception);
                }

                try
                {
                    if (currentParameter == BottleParameterType.NeckHeight)
                    {
                        _parameters.ValidateNeckHeight();
                    }
                }
                catch (ArgumentException exception)
                {
                    _exceptionsDictionary[currentParameter].Add(exception);
                }

                try
                {
                    if (currentParameter == BottleParameterType.NeckRadius)
                    {
                        _parameters.ValidateNeckRadius();
                    }
                }
                catch (ArgumentException exception)
                {
                    _exceptionsDictionary[currentParameter].Add(exception);
                }

                if (_exceptionsDictionary[currentParameter].Any())
                {
                    throw new AggregateException(_exceptionsDictionary[currentParameter]);
                }

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
                    _errors[currentParameter] += exception.Message;
                }

                _exceptionsDictionary[currentParameter].Clear();
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
