namespace BinarySearch
{
    using System.Text;

    public class TreeNod
    {
        public TreeNod(int key)
        {
            this.Key = key;
        }

        public int? Key { get; set; }

        public TreeNod LeftChild { get; set; }

        public TreeNod RightChild { get; set; }

        public void Add(int child)
        {
            if (child < this.Key)
            {
                if (this.LeftChild == null)
                {
                    this.LeftChild = new TreeNod(child);
                }
                else
                {
                    this.LeftChild.Add(child);
                }
            }
            else if (child > this.Key)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = new TreeNod(child);
                }
                else
                {
                    this.RightChild.Add(child);
                }
            }
        }

        public bool Contains(int number)
        {
            if (this.Key == number)
            {
                return true;
            }
            else
            {
                if (number < this.Key)
                {
                    if (this.LeftChild != null)
                    {
                        return this.LeftChild.Contains(number);
                    }
                }
                else if (number > this.Key)
                {
                    if (this.RightChild != null)
                    {
                        return this.RightChild.Contains(number);
                    }
                }
            }
         
            return false;
        }
    }
}