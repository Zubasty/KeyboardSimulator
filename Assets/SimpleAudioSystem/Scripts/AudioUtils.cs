using UnityEngine;

public static class AudioUtils
{
    /// <summary>
    /// Минимальный уровень громкости в децибелах, поддерживаемый Unity Audio Mixer.
    /// Ниже этого значения звук считается отключённым.
    /// </summary>
    public const float MinDecibels = -80f;

    /// <summary>
    /// Коэффициент для преобразования амплитуды (линейной громкости) в децибелы.
    /// Используется 20, потому что dB = 20 * log10(amplitude).
    /// </summary>
    private const float AmplitudeToDecibelFactor = 20f;

    /// <summary>
    /// Основание логарифма для обратного преобразования (10, так как используется log10).
    /// </summary>
    private const float LogBase = 10f;

    private static readonly float MinLinear = DecibelsToLinear(MinDecibels);

    public static float LinearToDecibels(float linear)
    {
        if (linear <= MinLinear)
            return MinDecibels;

        return Mathf.Log10(linear) * AmplitudeToDecibelFactor;
    }

    public static float DecibelsToLinear(float dB)
    {
        if (dB <= MinDecibels)
            return 0f;

        return Mathf.Pow(LogBase, dB / AmplitudeToDecibelFactor);
    }
}