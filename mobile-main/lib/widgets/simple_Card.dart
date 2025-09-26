import 'package:flutter/material.dart';

class CardPrincipal extends Card {
  /// Custom AppBar 
  final Widget child;
  const CardPrincipal({required this.child});
  @override

  @override
    Widget build(BuildContext context) {
      return Card(
       child: this.child,
      );
    }
}

