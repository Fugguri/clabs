using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using Lab5.Models;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        static ListBox taskBox;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            taskBox = this.FindControl<ListBox>("taskListBox");

            taskBox.Items.Add(new Task { Title = "Task 1", Description = "Description 1", Deadline = DateTime.Now.AddDays(1), Tags = new List<string> { "Tag1", "Tag2" } });
            taskBox.Items.Add(new Task { Title = "Task 2", Description = "Description 2", Deadline = DateTime.Now.AddDays(2), Tags = new List<string> { "Tag3", "Tag4" } });


        }


        // Обработчик двойного щелчка для отображения расширенной информации о задаче
        private void TaskListBox_DoubleTapped(object sender, RoutedEventArgs e)
        {
            if (taskBox.SelectedItem is Task selectedTask)
            {
                ShowTaskDetails(selectedTask);
            }
        }

        // Ваш код для отображения деталей задачи в диалоговом окне
        private void ShowTaskDetails(Task task)
        {
            // Ваш код для отображения деталей задачи в диалоговом окне
        }
        private void TaskListBox_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(null).Properties.IsRightButtonPressed)
            {
                ShowContextMenu();

            }
        }
        private void ShowContextMenu()
        {
            // Your code to show the context menu
            // You can use taskListBox.SelectedItem to get the selected task
        }


        // Обработчик открытия контекстного меню
        // private void TaskListBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        // {
        //     // Ваш код для отображения контекстного меню
        // }
    }
}

