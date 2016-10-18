using System.Collections.Generic;
using System.Data;

namespace Model
{
    public sealed class ComboInfo
    {
        private string _value;
        private string _text;

        public ComboInfo(string value, string text)
        {
            _value = value;
            _text = text;
        }

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
    }

    public sealed class Pagination
    {
        private int _index;
        private int _count;
        private int _total;

        public int page { set { _index = value; } }
        public int rows { set { _count = value; } }

        public int Begin { get { return (_index - 1) * _count; } }
        public int End { get { return _index * _count; } }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public Pagination() { }
        public Pagination(int index, int count)
        {
            _index = index;
            _count = count;
            _total = 0;
        }
    }

    public sealed class Datagrid
    {
        public DataTable rows { get; set; }
        public int total { get; set; }
    }

    public sealed class Tree
    {
        public int id { get; set; }
        public string text { get; set; }
		public bool Checked { get; set; }
		public List<Tree> children { get; set; }

        public Tree() { }
        public Tree(int id, string text)
        {
            this.id = id;
            this.text = text;
        }
    }
}
