using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using Lab5.Models;
using Lab5;
using Lab5.Serializers;
using Lab5.ViewModels;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        static ListBox taskBox;

        private static JsonObjectSerializer<Task> jsonSerializer = new JsonObjectSerializer<Task>();

        public TaskViewModel YourTaskViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            YourTaskViewModel = new TaskViewModel();
            DataContext = this;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            taskBox = this.FindControl<ListBox>("taskListBox");

            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
            foreach (Task task in tasks)
            {
                taskBox.Items.Add(task);
            }


        }

        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                // Создайте окно для редактирования задачи и передайте в него выбранную задачу
                var editTaskWindow = new EditTaskWindow(selectedTask);
                editTaskWindow.ShowDialog(this);

                // После закрытия окна обновите список задач, если были изменения
                List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
                UpdateTaskListBox(tasks);
            }
        }

        private void AddTaskMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.ShowDialog(this);

            // После закрытия окна обновите список задач, если были изменения
            List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
            UpdateTaskListBox(tasks);
            // addTaskWindow.Close();

        }


        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                List<Task> tasks = jsonSerializer.ReadDataFromFile("tasks.json");
                Console.WriteLine(tasks.Count);

                tasks.RemoveAll(x => x.Title == selectedTask.Title || x.Deadline == selectedTask.Deadline);
                Console.WriteLine(tasks.Count);

                selectedTask.Print();

                jsonSerializer.WriteDataToFile(tasks, "tasks.json");

                UpdateTaskListBox(tasks);
            }

        }

        private void UpdateTaskListBox(List<Task> tasks)
        {
            // Очистите ListBox и добавьте обновленные задачи
            taskBox.Items.Clear();
            foreach (Task task in tasks)
            {
                taskBox.Items.Add(task);
            }
            taskBox.InvalidateVisual();
        }
        private void TaskInfo_Click(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                ShowTaskDetails(selectedTask);
            }
            else
            {
                // Обработка ситуации, когда нет выбранного элемента
            }
        }
        private void ShowTaskDetails(Task task)
        {
            var detailsWindow = new TaskDetailsWindow(task);
            detailsWindow.ShowDialog(this);
        }

    }
}

