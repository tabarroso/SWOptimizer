   M S B A M L   `   `   `  ����F  BSWOptimizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SWOptimizerSWOptimizer  5   	       SWOptimizer.Log   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SWOptimizer     5   	     � Title$	  Log��5   	   $	��350��6   $	��525��6"   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.8* �6   �� 5      $��0.65* �6   �� 5      $
��0.7* �6   .+�5   
   �� $��
Connection��6    	  Title#��[  6%   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      � $��1��6    5      �� 5      $
��0.5* �6$   �� 5      .+�5      �� $��Pseudo: ��6     LegStat#��[ 6+   �� 5      -   5         ��Name$ 	PseudoBox��5   Y   $��1��6   $��Center=�6'   ��6B   �� *Login+6Y   5      � 5      $��2��6    5       �� 5!      $
��0.5* �6$   �� 5"      .+�5$      �� $��
Password: ��6   #��[ 6-   �� 5%      -   5        $ PasswordBox��5%   �   $��1��6   $��Center=�6'   ��6B   �� *PasswordChar+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5&      5'      � 5(   
   $��2��6    5)      �� 5*      �� 5+      �� 5,      �� 5-      .+�5/      � $��1��6    50      �� 51      �� 52      $
��0.5* �6$   �� 53      $
��0.5* �6$   .+�55      �� $��Confirm��6   $��Center=�6+     
ConfButton#��[ 6f   ��6F   �� *ConfCommand+6f   �� 56      $��2��6   $��Create Account��6'     OtherButton#��[ 6b   ��6@   �� *CreateCommand+6b   57      � 58      $��2��6    59      �� 5:      �� 5;      $
��0.5* �6$   �� 5<      $
��0.5* �6$   .+�5>      �� $��Cancel��6   $��Center=�6*     	DelButton#��[ 6g   ��6E   �� *CancelCommand+6g   �� 5?      $��2��6   $��Continue as Anonym��6'   #��[ 6f   ��6D   �� *AnonymCommand+6f   5@      5A      5B      5C      