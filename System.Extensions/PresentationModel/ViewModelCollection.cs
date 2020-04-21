﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.PresentationModel
{
    public class ViewModelCollection<TViewModel> : ObservableCollection<TViewModel>
        where TViewModel : ViewModel
    {
        public ICommand SaveCommand { get; }

        public ICommand SaveAllCommand { get; }

        protected readonly IList<TViewModel> deletedItems;

        public ViewModelCollection()
        {
            SaveCommand = new Command(async () => await Save());

            SaveAllCommand = new Command(async () => await SaveAll());

            deletedItems = new List<TViewModel>();
        }

        public ViewModelCollection(IList<TViewModel> list)
            : base(list)
        {
            SaveCommand = new Command(async () => await Save());

            SaveAllCommand = new Command(async () => await SaveAll());

            deletedItems = new List<TViewModel>();
        }

        protected override void InsertItem(int index, TViewModel item)
        {
            OnAddNew(item);

            base.InsertItem(index, item);
        }

        protected virtual void OnAddNew(TViewModel viewModel)
        {
            viewModel.State = ModelState.New;
        }

        public virtual async Task Save()
        {
            await Task.CompletedTask;
        }

        public virtual async Task SaveAll()
        {
            deletedItems.Clear();

            await Task.CompletedTask;
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];

            OnRemoveItem(item);

            base.RemoveItem(index);
        }

        protected virtual void OnRemoveItem(TViewModel viewModel)
        {
            viewModel.State = ModelState.Deleted;

            deletedItems.Add(viewModel);
        }

        public IEnumerable<TViewModel> GetItemsBy(ModelState state)
        {
            IEnumerable<TViewModel> items;

            if (state == ModelState.Deleted)
            {
                items = this.deletedItems;
            }
            else
            {
                items = this.Where(p => p.State == state);
            }

            return items;
        }

        protected virtual void OnItemSaved(TViewModel viewModel)
        {
            viewModel.OnSave();
        }

        public delegate void StatusChangedHandler(string status);

        public event StatusChangedHandler StatusChanged;

        protected void SetStatus(string status)
        {
            if (StatusChanged != null)
            {
                StatusChanged(status);
            }

            //mainToolStripStatusLabel.Text = value;

            //statusBarTimer.Enabled = true;
        }
    }
}
