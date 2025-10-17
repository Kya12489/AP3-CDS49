import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobil_cds49/models/categorie.dart';
import 'package:mobil_cds49/services/api/config.dart';

class CategorieApi {
  
  /// Permet de récupérer les questions d'un QCM
  static Future<List<Categorie>> getListeCategories() async {
      final response = await http.get(Uri.parse('${AppConfig.apiBaseUrl}/api/categories'));
      if (response.statusCode == 200) {
        final Map<String, dynamic> jsonData = json.decode(response.body);
        final List<dynamic> listeCategories = jsonData['data'];
        return listeCategories.map((q) => Categorie.fromJson(q)).toList();
      } else {
        throw Exception('Erreur lors de la récupération des catégories');
      }
  }
}