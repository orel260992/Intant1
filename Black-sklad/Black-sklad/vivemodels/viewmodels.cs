using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Runtime.InteropServices;

namespace Black_sklad.vivemodels
{
    class viewmodels : ViewModelBase
    {
        private Page warehous;
        private Page catalog;        
        private Page counterparties;
        private Page order_monitor;
        private Page statistics;

        private Page _courentPage;
        public Page CurrentPage 
        {
            get 
            {
                return _courentPage;
            } 
            set 
            {
                _courentPage = value; RaisePropertyChanged(() => CurrentPage); 
            } 
        }

        private double _frameOpacity;
        public double FrameOpacity;

        public viewmodels()
        {
            warehous = new pages.warehous();
            catalog = new pages.catalog();
            counterparties = new pages.counterparties();
            order_monitor = new pages.order_monitor();
            statistics = new pages.statistics();

            FrameOpacity = 1;
            CurrentPage = order_monitor;
        }

        public ICommand monitor_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(order_monitor));
            }
        }
     
        public ICommand catalog_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(catalog));
            }
        }
        public ICommand warehous_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(warehous));
            }
        }
        public ICommand counterpart_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(counterparties));
            }
        }
        public ICommand stat_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(statistics));
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }
    }
    
}
