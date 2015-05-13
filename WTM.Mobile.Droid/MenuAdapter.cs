using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WTM.Mobile.Droid
{
    public class MenuAdapter : RecyclerView.Adapter
    {
        private String[] dataset;
        private OnItemClickListener listener;

        public interface OnItemClickListener
        {
            void OnClick(View view, int position);
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public readonly TextView textView;
            public ViewHolder(TextView v)
                : base(v)
            {
                textView = v;
            }
        }

        public MenuAdapter(string[] myDataSet, OnItemClickListener listener)
        {
            dataset = myDataSet;
            this.listener = listener;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holderRaw, int position)
        {
            var holder = (ViewHolder)holderRaw;
            holder.textView.Text = dataset[position];
            holder.textView.Click += (object sender, EventArgs args) =>
            {
                listener.OnClick((View)sender, position);
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int p1)
        {
            var vi = LayoutInflater.From(parent.Context);
            var v = vi.Inflate(Resource.Layout.drawer_list_item, parent, false);
            var tv = v.FindViewById<TextView>(Android.Resource.Id.Text1);
            return new ViewHolder(tv);
        }

        public override int ItemCount
        {
            get { return dataset.Length; }
        }
    }
}