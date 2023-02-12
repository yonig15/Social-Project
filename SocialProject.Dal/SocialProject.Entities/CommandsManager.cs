//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SocialProject.Entities
//{
//    public class BaseCommand
//    {

//    }
//    public interface ICommand
//    {
//        object Execute(object param);
//    }
   
//    public class UserGetCmd :BaseCommand, ICommand
//    {
//        public class UserParam
//        {
//            public int Id;
//            public string Name;
//            public string Value;
//        }
//        public object Execute(object param)
//        {

//        }
//    }

//    public class UserPostCmd : BaseCommand, ICommand
//    {
//        public object Execute(object param)
//        {

//        }
//    }


//    public class CommandsManager :BacePromotionSystem
//    {
//        private Dictionary<string, ICommand> _commandList = null;
//        public Dictionary<string, ICommand> CommandList
//        {
//            get
//            {
//                if (_commandList == null) init();
//                return _commandList;
//            }
//        }
//        private void init()
//        {
//            _commandList = new Dictionary<string, ICommand>();
//            //Build all Dictionary
//            _commandList.Add("SProject.get-role", new UserGetCmd());
//        }
//    }
//}
