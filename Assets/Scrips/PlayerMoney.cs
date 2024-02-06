using System;

/// <summary>
/// ��������� �������� ��� ������ ����� ������
/// </summary>
public struct PlayerMoney
{
    private int _value; // ���������� ��������
    public int Value { get { return _value; } } // ������ _value

    /// <summary>
    /// ������� ��� ��������, ������� �� ����� � �������� ��� �������.
    /// </summary>
    /// <param name="cost">���� �������</param>
    /// <returns>Bool �������� ����: true - ������� ��������, false - ������� ����������.</returns>
    /// <exception cref="ArgumentException">��������� ��� ������������� �������� cost</exception>
    public bool IsBuyAvailable(int cost)
    {
        if (cost < 0) throw new ArgumentException($"��������� ��������� �� ����� ���� ���� ����! : cost = {cost}");
        if (_value < cost) return false;
        return true;
    }

    /// <summary>
    /// ������� "��������� ������"
    /// </summary>
    /// <param name="cost">��������� �������</param>
    /// <returns>���������� ���������� �����</returns>
    public int Spend(int cost)
    {
        if (IsBuyAvailable(cost)) _value -= cost;
        return Value;
    }

    /// <summary>
    /// �������, ����������� PlayerMoney.Spend(int).
    /// </summary>
    /// <param name="cost">��������� �������</param>
    /// <returns>Bool �������� ����: true - ������� �������, false - ������� ���������.</returns>
    public bool TryToSpend(int cost)
    {
        bool res = IsBuyAvailable(cost);
        if (res) _value -= cost;
        return res;
    }

    public PlayerMoney(int value)
    {
        _value = value;
    }

    public static implicit operator PlayerMoney(int v)
    {
        return new PlayerMoney(v);
    }

    public static PlayerMoney operator +(PlayerMoney money, int value) => new PlayerMoney(money.Value + value);

    public override string ToString() => Value.ToString();
}