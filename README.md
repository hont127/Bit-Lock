# Bit-Lock
A simple bit lock tool.一个简单的位锁工具。

### How To Use:
A Bit-Lock tool that can be used for regist and unregist of multiple objects.
</br>位锁可以用于多个对象的注册反注册，或是左手右手的操作锁等等
```C#
var bitLock = new BitLock();
var lockHandle = bitLock.AssignLock();
//bitLock.IsLocked true
bitLock.UnassignLock(lockHandle);
//bitLock.IsLocked false
```

or like this
</br>或者像这样使用
```C#
BitLock bitLock = new BitLock();
bitLock.AssignAutoLock();
bitLock.AssignAutoLock();
bitLock.AssignAutoLock();
//bitLock.IsLocked true
bitLock.UnassignAutoLock();
bitLock.UnassignAutoLock();
bitLock.UnassignAutoLock();
//bitLock.IsLocked false
```
