import 'dart:convert';

import 'package:http/http.dart' as http;

import 'package:mobil_cds49/services/api/config.dart';
import 'package:mobil_cds49/services/gestion_token/token.dart';

class DocumentApi {
  Future<int> getDocumentInWaiting() async {
    try {
      final token = await GestionToken.getToken();
      final response = await http.get(
        Uri.parse('${AppConfig.apiBaseUrl}/api/documents/waiting'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Authorization': 'Bearer $token',
        },
      );

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);
        return data['count'] ?? 0;
      } else {
        return 0;
      }
    } catch (e) {
      return 0;
    }
  }
}
