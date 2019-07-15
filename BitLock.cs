using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hont
{
    public class BitLock
    {
        const int LOCKED_MAX_VALUE = 32;

        int mBitSlot;

        public bool IsLocked { get { return mBitSlot != 0; } }


        public BitLock()
        {
        }

        public bool IsUnassignLock(int handle)
        {
            return (mBitSlot & handle) == 0;
        }

        /// <summary>
        /// 分配一个锁，并返回锁的句柄。如果返回-1则返回失败。
        /// </summary>
        public int AssignLock()
        {
            int result = -1;

            for (int i = 1; i <= LOCKED_MAX_VALUE; i++)
            {
                if ((mBitSlot & (1 << i)) == 0)
                {
                    mBitSlot |= 1 << i;

                    result = i;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 分配一个自动锁。
        /// </summary>
        public void AssignAutoLock()
        {
            for (int i = 1; i <= LOCKED_MAX_VALUE; i++)
            {
                if ((mBitSlot & (1 << i)) == 0)
                {
                    mBitSlot |= 1 << i;
                    break;
                }
            }
        }

        /// <summary>
        /// 放回一个自动锁。
        /// </summary>
        public void UnassignAutoLock()
        {
            for (int i = 1; i <= LOCKED_MAX_VALUE; i++)
            {
                var mask = 1 << i;

                if ((mBitSlot & mask) == mask)
                {
                    mBitSlot = mBitSlot & (~mask);
                    break;
                }
            }
        }

        /// <summary>
        /// 通过句柄放回一个锁。
        /// </summary>
        public void UnassignLock(int handle)
        {
            mBitSlot = mBitSlot & (~(1 << handle));
        }

        public void ReleasedAllLock()
        {
            mBitSlot = 0;
        }
    }
}