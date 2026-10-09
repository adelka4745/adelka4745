<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

    <Style x:Key="NavButtonStyle" TargetType="Button">
        <Setter Property="Height" Value="42"/>
        <Setter Property="Margin" Value="0,0,0,8"/>
        <Setter Property="Foreground" Value="#E6E9F5"/>
        <Setter Property="Background" Value="#1A1B2A"/>
        <Setter Property="BorderBrush" Value="#2E2E45"/>
        <Setter Property="BorderThickness" Value="1"/>
        <Setter Property="HorizontalContentAlignment" Value="Left"/>
        <Setter Property="Padding" Value="12,0,0,0"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="10">
                        <ContentPresenter HorizontalAlignment="Left" VerticalAlignment="Center" Margin="12,0,0,0"/>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="#24263A"/>
                <Setter Property="BorderBrush" Value="#6CF0FF"/>
            </Trigger>
        </Style.Triggers>
    </Style>

</ResourceDictionary>
