using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoCAD_Plugin_Bottle.Model;

namespace AutoCAD_Plugin_Bottle.View
{
	/// <summary>
	/// Форма для задания параметров бутылки.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Бутылка.
		/// </summary>
		private Bottle _bottle = new Bottle();

		/// <summary>
		/// Цвет элементов формы при отсутствии ошибок.
		/// </summary>
		private Color _defaultColor = Color.White;

		/// <summary>
		/// Цвет элементов формы при наличии ошибок.
		/// </summary>
		private Color _errorColor = Color.LightPink;

		/// <summary>
		/// Словарь ошибок.
		/// </summary>
		private Dictionary<string, string> _errorDictionary = new Dictionary<string, string>()
		{
			{nameof(Model.Bottle.Length), "" },
			{nameof(Model.Bottle.Width), "" },
			{nameof(Model.Bottle.MainHeight), "" },
			{nameof(Model.Bottle.NeckHeight), "" },
			{nameof(Model.Bottle.NeckRadius), "" }
		};

		public MainForm()
		{
			InitializeComponent();
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

			foreach (var error in _errorDictionary)
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
		/// Присваивает введеную в поле длину в соответствующее
		/// поле класса и валидирует его.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LengthTextBox_TextChanged(object sender, EventArgs e)
		{
			/*try
			{
				_bottle.Length = double.Parse(LengthTextBox.Text);
				LengthTextBox.BackColor = _defaultColor;
				_errorDictionary[nameof(Bottle.Length)] = "";
			}
			catch (ArgumentException ex)
			{
				_errorDictionary[nameof(Bottle.Length)] = ex.Message;
				LengthTextBox.BackColor = _errorColor;
			}*/
		}

		/// <summary>
		/// Присваивает введеную в поле ширину в соответствующее
		/// поле класса и валидирует его.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WidthTextBox_TextChanged(object sender, EventArgs e)
		{
			/*try
			{
				_bottle.Width = double.Parse(WidthTextBox.Text);
				WidthTextBox.BackColor = _defaultColor;
				_errorDictionary[nameof(Bottle.Width)] = "";
			}
			catch (ArgumentException ex)
			{
				_errorDictionary[nameof(Bottle.Width)] = ex.Message;
				WidthTextBox.BackColor = _errorColor;
			}*/
		}

		/// <summary>
		/// Присваивает введеную в поле высоту основной части в соответствующее
		/// поле класса и валидирует его.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainHeightTextBox_TextChanged(object sender, EventArgs e)
		{
			/*try
			{
				_bottle.MainHeight = double.Parse(MainHeightTextBox.Text);
				MainHeightTextBox.BackColor = _defaultColor;
				_errorDictionary[nameof(Bottle.MainHeight)] = "";
			}
			catch (ArgumentException ex)
			{
				_errorDictionary[nameof(Bottle.MainHeight)] = ex.Message;
				MainHeightTextBox.BackColor = _errorColor;
			}*/
		}

		/// <summary>
		/// Присваивает введеную в поле высоту горлышка в соответствующее
		/// поле класса и валидирует его.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NeckHeightTextBox_TextChanged(object sender, EventArgs e)
		{
			/*try
			{
				_bottle.NeckHeight = double.Parse(NeckHeightTextBox.Text);
				NeckHeightTextBox.BackColor = _defaultColor;
				_errorDictionary[nameof(Bottle.NeckHeight)] = "";
			}
			catch (ArgumentException ex)
			{
				_errorDictionary[nameof(Bottle.NeckHeight)] = ex.Message;
				NeckHeightTextBox.BackColor = _errorColor;
			}*/
		}

		/// <summary>
		/// Присваивает введеный в поле радиус горлышка в соответствующее
		/// поле класса и валидирует его.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NeckRadiusTextBox_TextChanged(object sender, EventArgs e)
		{
			/*try
			{
				_bottle.NeckRadius = double.Parse(NeckRadiusTextBox.Text);
				NeckRadiusTextBox.BackColor = _defaultColor;
				_errorDictionary[nameof(Bottle.NeckRadius)] = "";
			}
			catch (ArgumentException ex)
			{
				_errorDictionary[nameof(Bottle.NeckRadius)] = ex.Message;
				NeckRadiusTextBox.BackColor = _errorColor;
			}*/
		}

		private void LengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			/*if (e.KeyChar >= '0' && e.KeyChar <= '9')
			{
				return;
			}
			e.Handled = true;*/
		}
	}
}
