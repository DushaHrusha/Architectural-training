using System.ComponentModel;
using CodeBase.Infrastructure;
using UnityEditor.IMGUI.Controls;

namespace Architectural_training.Assets.CodeBase.Infrastructure.Services
{
    public class AllSerices
    {
        private static AllSerices _instance;
        public static AllSerices  Container => _instance ?? (_instance = new AllSerices());

        public void RegisterSingle<TSercies>(TSercies implementation) where TSercies : ISercies
        {
            Implementation<TSercies>.SerciesInstanse = implementation;
        }

        public TSercies Single<TSercies>() where TSercies : ISercies
        {
            return Implementation<TSercies>.SerciesInstanse;
        }
        
        private static class Implementation<TSercies> where TSercies : ISercies
        {
            public static TSercies SerciesInstanse;
            
        }
    }
}  