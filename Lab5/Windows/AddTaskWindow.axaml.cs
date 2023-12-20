// AddTaskWindow.axaml.cs
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Lab5.Models;
using Lab5.Serializers;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Lab5
{
    public partial class AddTaskWindow : Window
    {
        private TextBox titleTextBox;
        // private DatePicker deadlinePicker;
        private static JsonObjectSerializer<Task> jsonSerializer = new JsonObjectSerializer<Task>();

        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            addTitleTextBox = this.FindControl<TextBox>("addTitleTextBox");
            addDescriptionTextBox = this.FindControl<TextBox>("addDescriptionTextBox");
            addDeadlinePicker = this.FindControl<DatePicker>("addDeadlinePicker");
            addTagsTextBox = this.FindControl<TextBox>("addTagsTextBox");

        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик кнопки "Add Task"
            string title = addTitleTextBox.Text;
            DateTime selectedDate = addDeadlinePicker.SelectedDate.Value.DateTime;
            // DateTime dateTime = selectedDate?.LocalDateTime ?? DateTime.Now;
            string description = addDescriptionTextBox.Text;

            string tags = string.Join(" ", addTitleTextBox.Text);


            // Создайте новую задачу
            Task newTask = new Task { Title = title, Description = description, Deadline = selectedDate, Tags = tags };

            // Добавьте новую задачу в список задач
            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
            tasks.Add(newTask);
            jsonSerializer.WriteDataToFile(tasks, "tasks.json");
            // // Закроем окно после добавления задачи

            Close();

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
