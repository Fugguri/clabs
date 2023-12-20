using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Lab5.Models;
using Lab5.Serializers;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace Lab5
{
    public partial class EditTaskWindow : Window
    {
        public EditTaskWindow(Task task)
        {
            InitializeComponent(task);
            DataContext = task;
        }


        private void InitializeComponent(Task task)
        {
            AvaloniaXamlLoader.Load(this);
            editTitleTextBox = this.FindControl<TextBox>("editTitleTextBox");
            editDescriptionTextBox = this.FindControl<TextBox>("editDescriptionTextBox");
            editDeadlinePicker = this.FindControl<DatePicker>("editDeadlinePicker");
            editTagsTextBox = this.FindControl<TextBox>("editTagsTextBox");

            // // Установите дату в editDeadlinePicker
            editDeadlinePicker.SelectedDate = new DateTimeOffset(task.Deadline); // Используйте конструктор DateTimeOffset

            // editTagsTextBox.Text = task.Tags;
        }







        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveEditedTask_Click(object sender, RoutedEventArgs e)
        {

            Task editedTask = (Task)DataContext;
            editedTask.Title = editTitleTextBox.Text;
            editedTask.Description = editDescriptionTextBox.Text;

            // Проверка, имеет ли Deadline значение
            if (editDeadlinePicker.SelectedDate.HasValue)
            {
                editedTask.Deadline = editDeadlinePicker.SelectedDate.Value.DateTime;
            }
            editedTask.Tags = editTagsTextBox.Text;

            editedTask.Print();

            Close(); // Закрытие окна редактирования
        }
    }
}
