   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Vkr_WPF.Views.WindowsVkr_WPF.Views.Windows  5   	   /    )Vkr_WPF.Views.Windows.AuthorizationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Vkr_WPF.Views.Windows     5   	     � Title$%  Окно авторизации��5   	   $	��430��6"   $	��600��6/   $0��*/Vkr_WPF;component/Fonts/#Natural Mono Alt)�5	   	   ���#33334C � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%�  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ 30(�6)   �� 5       � ��$ Center=�64   �� 5       � �� �#DBDBEA6+   �� 5       � ��$ 5q�6'   5      �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5       $
��0.4* �6   �� 5!      $��1* �6   �� 5"      $
��0.4* �6    � RowDefinitions 5$   
   �� 5%      $��0.15* �6   �� 5&      $��1* �6   .+�5(   
   �� 	 �� Orientation$	 Vertical=�6   $��1��6,   $��1��5)      .+�5*      �� $��
Логин��6   #��[  6$   �� 5+      
 �� CornerRadius$
 10��6   ���#0D0D2E$	��300��5-      $��50��5.      $��5q�5/      ._�50      � .+�51      �� $��1��6    �� 52      -   5         ��Name$ LoginTextBox��53      #��[ 52      ��53   4   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 54       J� IsHitTestVisible .  $��
Логин��55       $��Center=�56       $
��Left=�57       
�������$��13(�59        �� Padding$ 5q�5:       $��10,0,0,0q�5;       ��5<      �� 5=      " ��6$    �� Triggers 5>   "   �� 5?   &    �� Binding 62   �� *Text+ �� ElementName$ LoginTextBox�� �� Value  6e   .a�5@   *   ��  � y�$ Visible=�6G   5A   '   .�5C   "   ��  � y�$ Hidden=�6?   5D      5F      5G      5H      �� 5J      $��Пароль��6   #��[  6%   �� 5K      $
 10��6   ���#0D0D2E$	��300��5M      $��50��5N      $��5q�5O      ._�5P      � .+�5Q      �� $��1��6    G� 5R      -   5         G�Name$ PasswordBoxPassword��5R   H   #��[ 6"   6H   5S      5T      �� 5U      $
 15��6   ���#0D0D2E$	��300��5W      $��50��5X      $��5q�5Y      ._�5Z      � .+�5[      �� $��1��6    �� 5\      $	��300��6   
������ $��0q�5]   !   $"��Авторизоваться��5^   !   ���#DBDBEA$��20(�5`   !   ��6/   �� *AuthenticateCommand+��6W   �� $ PasswordBoxPassword��5a      5b      5c      5d      5e      