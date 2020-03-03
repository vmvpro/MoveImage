using System;
using System.Collections.Generic;
using System.Text;

namespace CheckComboBox {
    public class CheckedComboBoxItem {
        private int val;
        public int Value {
            get { return val; }
            set { val = value; }
        }
        
        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        public CheckedComboBoxItem() {
        }

        public CheckedComboBoxItem(string name, int val) {
            this.name = name;
            this.val = val;
        }

        public override string ToString() {
            return string.Format("name: '{0}', value: {1}", name, val);
        }
    }
}
