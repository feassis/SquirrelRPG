public class Character
{
    public int momentum;
    private int maxHP;
    private int currentHP;
    private int maxMP;
    private int currentMP;
    private int maxSP;
    private int currentSP;

    public Character(int momentum, int maxHP, int currentHP, int maxMP, int currentMP, int maxSP, int currentSP)
    {
        this.momentum = momentum;
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.maxMP = maxMP;
        this.currentMP = currentMP;
        this.maxSP = maxSP;
        this.currentSP = currentSP;
    }
}
