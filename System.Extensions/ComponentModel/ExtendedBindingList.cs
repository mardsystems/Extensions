using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public class ExtendedBindingList<T> : BindingList<T>
        where T : ObservableObject
    {
        private readonly IList<T> deletedItems;

        public ExtendedBindingList()
        {
            deletedItems = new List<T>();
        }

        public ExtendedBindingList(IList<T> list)
            : base(list)
        {
            deletedItems = new List<T>();
        }

        protected override object AddNewCore()
        {
            var viewModel = (T)base.AddNewCore();

            OnAddNew(viewModel);

            return viewModel;
        }

        protected virtual void OnAddNew(T viewModel)
        {
            viewModel.State = ObjectState.New;
        }

        public virtual async Task SaveChanges()
        {
            deletedItems.Clear();

            await Task.FromResult(true);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];

            item.State = ObjectState.Deleted;

            deletedItems.Add(item);

            base.RemoveItem(index);
        }

        public IEnumerable<T> GetItemsBy(ObjectState state)
        {
            IEnumerable<T> items;

            if (state == ObjectState.Deleted)
            {
                items = this.deletedItems;
            }
            else
            {
                items = this.Where(p => p.State == state);
            }

            return items;
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
