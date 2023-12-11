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
        private readonly Dictionary<BottleParameterType, string> _errors;

        /// <summary>
        /// Словарь названий параметров.
        /// </summary>
        private readonly Dictionary<BottleParameterType, string> _parameterNames;

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
        /// Цвет элементов формы при их отключении.
        /// </summary>
        private readonly Color _disabledColor = Color.LightGray;

        /// <summary>
        /// Флаг, определяющий выбранную форму основания главной части:
        /// true - окружность, false - прямоугольник.
        /// </summary>
        private bool _isMainCircle = false;

        /// <summary>
        /// Флаг, определяющий выбранную форму основания горлышка:
        /// true - окружность, false - прямоугольник.
        /// </summary>
        private bool _isNeckRectangle = false;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _parameterControls = new Dictionary<BottleParameterType, TextBox>
            {
                { BottleParameterType.MainLength, MainLengthTextBox },
                { BottleParameterType.MainWidth, MainWidthTextBox },
                { BottleParameterType.MainHeight, MainHeightTextBox },
                { BottleParameterType.NeckHeight, NeckHeightTextBox },
                { BottleParameterType.NeckRadius, NeckRadiusTextBox },
                { BottleParameterType.NeckLength, NeckLengthTextBox },
                { BottleParameterType.NeckWidth, NeckWidthTextBox },
                { BottleParameterType.MainRadius, MainRadiusTextBox }
            };

            _errors = new Dictionary<BottleParameterType, string>
            {
                { BottleParameterType.MainLength, "" },
                { BottleParameterType.MainWidth, "" },
                { BottleParameterType.MainHeight, "" },
                { BottleParameterType.NeckHeight, "" },
                { BottleParameterType.NeckRadius, "" },
                { BottleParameterType.NeckLength, "" },
                { BottleParameterType.NeckWidth, "" },
                { BottleParameterType.MainRadius, "" }
            };

            _parameterNames = new Dictionary<BottleParameterType, string>
            {
                { BottleParameterType.MainLength, "Длина" },
                { BottleParameterType.MainWidth, "Ширина" },
                { BottleParameterType.MainHeight, "Высота основной части" },
                { BottleParameterType.NeckHeight, "Высота горлышка" },
                { BottleParameterType.NeckRadius, "Радиус горлышка" },
                { BottleParameterType.NeckLength, "Длина горлышка" },
                { BottleParameterType.NeckWidth, "Ширина горлышка" },
                { BottleParameterType.MainRadius, "Радиус основной части" }
            };

            RectangleMainRadioButton.Checked = true;
            RoundNeckRadioButton.Checked = true;
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
            NeckWidthTextBox.Text = "";
            NeckLengthTextBox.Text = "";
            MainRadiusTextBox.Text = "";
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
                if (_parameterControls[parameterType].Text == ""
                    && _parameterControls[parameterType].Enabled)
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
        /// Изменяет доступные элементы управления на форме для основной части бутылки.
        /// </summary>
        private void ChangeMainEnabledControls()
        {
            if (_isMainCircle)
            {
                MainRadiusTextBox.Enabled = true;
                MainLengthTextBox.Enabled = false;
                MainWidthTextBox.Enabled = false;

                MainRadiusTextBox.BackColor = _defaultColor;
                MainLengthTextBox.BackColor = _disabledColor;
                MainWidthTextBox.BackColor = _disabledColor;
            }
            else
            {
                MainRadiusTextBox.Enabled = false;
                MainLengthTextBox.Enabled = true;
                MainWidthTextBox.Enabled = true;

                MainRadiusTextBox.BackColor = _disabledColor;
                MainLengthTextBox.BackColor = _defaultColor;
                MainWidthTextBox.BackColor = _defaultColor;
            }
        }

        /// <summary>
        /// Изменяет доступные элементы управления на форме для горлышка бутылки.
        /// </summary>
        private void ChangeNeckEnabledControls()
        {
            if (_isNeckRectangle)
            {
                NeckRadiusTextBox.Enabled = false;
                NeckLengthTextBox.Enabled = true;
                NeckWidthTextBox.Enabled = true;

                NeckRadiusTextBox.BackColor = _disabledColor;
                NeckLengthTextBox.BackColor = _defaultColor;
                NeckWidthTextBox.BackColor = _defaultColor;
            }
            else
            {
                NeckRadiusTextBox.Enabled = true;
                NeckLengthTextBox.Enabled = false;
                NeckWidthTextBox.Enabled = false;

                NeckRadiusTextBox.BackColor = _defaultColor;
                NeckLengthTextBox.BackColor = _disabledColor;
                NeckWidthTextBox.BackColor = _disabledColor;
            }
        }

        /// <summary>
        /// Очищает отключенные параметры.
        /// </summary>
        private void ClearDisabledParameters()
        {
            if (_isMainCircle)
            {
                _parameters[BottleParameterType.MainLength].ReturnToDefaultValue();
                _parameters[BottleParameterType.MainWidth].ReturnToDefaultValue();
                MainLengthTextBox.Text = "";
                MainWidthTextBox.Text = "";
            }
            else
            {
                _parameters[BottleParameterType.MainRadius].ReturnToDefaultValue();
                MainRadiusTextBox.Text = "";
            }

            if (_isNeckRectangle)
            {
                _parameters[BottleParameterType.NeckRadius].ReturnToDefaultValue();
                NeckRadiusTextBox.Text = "";
            }
            else
            {
                _parameters[BottleParameterType.NeckLength].ReturnToDefaultValue();
                _parameters[BottleParameterType.NeckWidth].ReturnToDefaultValue();
                NeckLengthTextBox.Text = "";
                NeckWidthTextBox.Text = "";
            }
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
                    if (_parameterControls[currentParameter].Enabled)
                    {
                        _parameterControls[currentParameter].BackColor = _defaultColor;
                    }
                    else
                    {
                        _parameterControls[currentParameter].BackColor = _disabledColor;
                    }

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

            ClearDisabledParameters();
            _parameters.IsMainCircle = _isMainCircle;
            _parameters.IsNeckRectangle = _isNeckRectangle;
            Builder.BuildBottle(_parameters);
            ClearForm();
        }

        /// <summary>
        /// Обработчик события нажатия на RoundMainRadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundMainRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isMainCircle = true;
            ChangeMainEnabledControls();
            ClearDisabledParameters();
            _parameters.IsMainCircle = _isMainCircle;
        }

        /// <summary>
        /// Обработчик события изменения состояния RectangleMainRadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleMainRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isMainCircle = false;
            ChangeMainEnabledControls();
            ClearDisabledParameters();
            _parameters.IsMainCircle = _isMainCircle;
        }

        /// <summary>
        /// Обработчик события изменения состояния RoundNeckRadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoundNeckRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isNeckRectangle = false;
            ChangeNeckEnabledControls();
            ClearDisabledParameters();
            _parameters.IsNeckRectangle = _isNeckRectangle;
        }

        /// <summary>
        /// Обработчик события изменения состояния RectangleNeckRadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectangleNeckRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isNeckRectangle = true;
            ChangeNeckEnabledControls();
            ClearDisabledParameters();
            _parameters.IsNeckRectangle = _isNeckRectangle;
        }
    }
}
