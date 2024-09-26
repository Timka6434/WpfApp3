using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PocketFinansistWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WpfApp3.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Тут указана логика для навигации в программе
        /// </summary>
        private Frame _mainFrame;

        public void SetFrame(Frame frame)
        {
            _mainFrame = frame;
        }
        [RelayCommand]
        public void Navigate(object parameter)
        {
            if (parameter is string pageName)
            {
                Type pageType = Type.GetType(pageName);

                if (pageType != null)
                {
                    Page pageInstance = (Page)Activator.CreateInstance(pageType);
                    _mainFrame.Navigate(pageInstance);
                }
                else
                {
                    MessageBox.Show($"Страница > {pageName} < не найдена!");
                    return;
                }

            }


        }
    }
}
