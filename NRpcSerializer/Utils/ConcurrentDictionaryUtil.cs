﻿using System;
using System.Collections.Concurrent;

namespace NRpcSerializer.Utils
{
    /// <summary>
    /// 类名：ConcurrentDictionaryUtil.cs
    /// 类功能描述：
    /// 创建标识：yjq 2018/5/7 11:18:47m
    /// </summary>
    internal static class ConcurrentDictionaryUtil
    {
        public static bool Remove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dict, TKey key)
        {
            TValue value;
            return dict.TryRemove(key, out value);
        }

        /// <summary>
        /// ConcurrentDictionary 获取值的扩展方法
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="conDic">字典集合</param>
        /// <param name="key">键值</param>
        /// <param name="action">获取值的方法(使用时需要执行注意方法闭包)</param>
        /// <returns>指定键的值</returns>
        public static TValue GetValue<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> conDic, TKey key, Func<TValue> action)
        {
            TValue value;
            if (conDic.TryGetValue(key, out value)) return value;
            value = action();
            conDic[key] = value;
            return value;
        }
    }
}