using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Khalil
{
    class z_Product_Object
    {
        

        public int Product_Id;
        public List<z_Product_Component> Product_Components;

        public z_Product_Object(int Product_Id, List<z_Product_Component> Product_Components)
        {
            this.Product_Id = Product_Id;
            this.Product_Components = Product_Components;

        }

        


        public static List<z_Product_Component> SumOfMaterial(List<z_Product_Object> z_Product_ObjectList)
        {

            List<z_Product_Component> newDeteils = new List<z_Product_Component>();

            List<z_Product_Component> ProductDetails = new List<z_Product_Component>();
            foreach(z_Product_Object item in z_Product_ObjectList)
            {
                ProductDetails = item.Product_Components;

                foreach(z_Product_Component  obj in ProductDetails)
                {
                    if (newDeteils.Count < 1)
                        newDeteils.Add(obj);
                    else
                    {
                        bool found = true;
                        int OldIndex = 0;
                        double OldQuan = 0;
                        foreach (z_Product_Component newObj in newDeteils)
                        {
                            if(newObj.MatrialName==obj.MatrialName)
                            {
                                OldQuan = newObj.Quantitiy;
                                OldIndex = newDeteils.IndexOf(newObj);
                                found = false;
                                break;
                            }
                        }
                        if(found)
                        {
                            newDeteils.Add(obj);
                        }
                        else
                        {
                            newDeteils.RemoveAt(OldIndex);
                            newDeteils.Add(new z_Product_Component(obj.MatrialName, obj.Quantitiy + OldQuan));
                        }
                    }

                }
               
            }

            return newDeteils;
        }


    }
}
