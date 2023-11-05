using AutoCAD_Plugin_Bottle.Model;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCAD_Plugin_Bottle.View
{
	/// <summary>
	/// Форма для задания параметров бутылки.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Словарь ошибок.
		/// </summary>
		private Dictionary<string, string> _errors = new Dictionary<string, string>();

		/// <summary>
		/// Словарь текстбоксов.
		/// </summary>
		private Dictionary<ParameterType, TextBox> _parameterControls = new Dictionary<ParameterType, TextBox>()
		{
			{ParameterType.Length, null },
			{ParameterType.Width, null },
			{ParameterType.MainHeight, null },
			{ParameterType.NeckHeight, null },
			{ParameterType.NeckRadius, null },
		};

		/// <summary>
		/// Параметры модели
		/// </summary>
		private Parameters _parameters;

		/// <summary>
		/// Транзакция.
		/// </summary>
		private Transaction _transaction;

		/// <summary>
		/// Цвет элементов формы при отсутствии ошибок.
		/// </summary>
		private Color _defaultColor = Color.White;

		/// <summary>
		/// Цвет элементов формы при наличии ошибок.
		/// </summary>
		private Color _errorColor = Color.LightPink;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Свойство транзакции.
		/// </summary>
		public Transaction Transaction
		{
			get;
			set;
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
		private bool CheckFormOnErrors()
		{
			string allErrors = "";

			foreach (var error in _errors)
			{
				if (error.Value != "")
				{
					allErrors += error.Value + "\n";
				}
			}

			if (allErrors != "")
			{
				MessageBox.Show(allErrors, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Проверяет тип текстбокса.
		/// </summary>
		/// <param name="textBox">Текстбокс.</param>
		/// <returns>Тип параметра.</returns>
		private ParameterType CheckTextBoxType(TextBox textBox)
		{
			switch (textBox.Name)
			{
				case "LengthTextBox":
					{
						return ParameterType.Length;
					};
				case "WidthTextBox":
					{
						return ParameterType.Width;
					};
				case "MainHeightTextBox":
					{
						return ParameterType.MainHeight;
					};
				case "NeckHeightTextBox":
					{
						return ParameterType.NeckHeight;
					};
				case "RadiusTextBox":
					{
						return ParameterType.NeckRadius;
					};
				default: return ParameterType.NeckRadius;
			}
		}

		/// <summary>
		/// Обработчик события ввода текста в текстбокс.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTextChanged(object sender, EventArgs e)
		{
			try
			{
				ParameterType currentParameter = CheckTextBoxType((TextBox)sender);
				_parameterControls[currentParameter] = (TextBox)sender;
				_parameters.ParameterDictionary[currentParameter].Value =
					double.Parse(_parameterControls[currentParameter].Text);
				_parameters.ValidateDependentParameters();
			}
			catch (ArgumentException ex)
			{
				ParameterType currentParameter = CheckTextBoxType((TextBox)sender);
				_parameterControls[currentParameter] = (TextBox)sender;
			}
		}

		private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			/*if (e.KeyChar >= '0' && e.KeyChar <= '9')
			{
				return;
			}
			e.Handled = true;*/
		}

		private void CreateButton_Click(object sender, EventArgs e)
		{

		}
	}
}
