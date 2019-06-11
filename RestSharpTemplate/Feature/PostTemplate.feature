Feature: PostTemplate
	So that i can create a request with specific template
	As a Customer
	I want to make a request to the endpoint with different templates

Scenario: Posting outputs with a template id of HARPA001
	When I request outputs with 'HARPA001'
	Then I should receive status code 'OK'

Scenario:  when i get missing documents request data
	When I request outputs with json Format 'MissingDocuments'

Scenario:  when i get missing documents request data get count
	When I have 'MissingDocuments' get count

Scenario Outline: When Client Request template
	When I request outputs with '<template-type>'
	Then I should receive status code 'OK'

	Examples:
		| template-type   |
		| BH_C1_NQ_001_01 |
		| BH_C1_NQ_001_02 |
		| BH_C1_NQ_002_01 |
		| BH_C1_NQ_002_02 |
		| BH_C1_NQ_003_01 |
		| BH_C1_NQ_003_02 |
		| BH_C1_NQ_004_01 |
		| BH_C1_NQ_005_01 |
		| BH_C1_NQ_006_01 |
		| BH_C1_NQ_007_01 |
		| BH_C1_NQ_007_02 |
		| BH_C1_NQ_008_01 |
		| BH_C1_NQ_008_02 |
		| BH_C1_NQ_009_01 |
		| BH_C1_NQ_009_02 |
		| BH_C1_NQ_010_01 |
		| BH_C1_NQ_010_02 |
		| BH_C1_NQ_011_01 |
		| BH_C1_NQ_011_02 |
		| BH_C1_NQ_012_01 |
		| BH_C1_NQ_012_02 |
		| BH_C1_NQ_013_01 |
		| BH_C1_NQ_013_02 |
		| BH_C1_NQ_014_01 |
		| BH_C1_NQ_015_01 |
		| BH_C1_NQ_015_02 |
		| BH_C1_NQ_016_01 |
		| BH_C1_NQ_016_02 |
		| BH_C1_NQ_017_01 |
		| BH_C1_NQ_018_01 |
		| BH_C1_NQ_019_01 |
		| BH_C1_NQ_019_02 |
		| BH_C1_NQ_020_01 |
		| BH_C1_NQ_020_02 |
		| BH_C1_NQ_021_01 |
		| BH_C1_NQ_021_02 |
		| BH_C1_NQ_022_01 |
		| BH_C1_NQ_022_02 |
		| BH_C1_NQ_023_01 |
		| BH_C1_NQ_024_01 |
		| BH_C1_NQ_025_01 |
		| BH_C1_NQ_026_01 |
		| BP_C1_NQ_001_01 | 
		| BP_C1_NQ_001_02 |  
		| BP_C1_NQ_002_01 | 
		| BP_C1_NQ_002_02 | 
		| BP_C1_NQ_003_01 |  
		| BP_C1_NQ_003_02 |  
		| BP_C1_NQ_004_01 |  
		| BP_C1_NQ_005_01 |  
		| BP_C1_NQ_006_01 |  
		| BP_C1_NQ_007_01 |  
		| BP_C1_NQ_007_02 |  
		| BP_C1_NQ_008_01 |  
		| BP_C1_NQ_008_02 | 
		| BP_C1_NQ_009_01 | 
		| BP_C1_NQ_009_02 |  
		| BP_C1_NQ_010_01 |  
		| BP_C1_NQ_010_02 | 
		| BP_C1_NQ_011_01 | 
		| BP_C1_NQ_011_02 | 
		| BP_C1_NQ_012_01 |  
		| BP_C1_NQ_012_02 | 
		| BP_C1_NQ_013_01 |  
		| BP_C1_NQ_013_02 | 
		| BP_C1_NQ_014_01 |  
		| BP_C1_NQ_015_01 | 
		| BP_C1_NQ_015_02 |  
		| BP_C1_NQ_016_01 |  
		| BP_C1_NQ_016_02 |  
		| BP_C1_NQ_017_01 |
		| BP_C1_NQ_018_01 |
		| BP_C1_NQ_019_01 |
		| BP_C1_NQ_019_02 |
		| BP_C1_NQ_020_01 |
		| BP_C1_NQ_020_02 |
		| BP_C1_NQ_021_01 |
		| BP_C1_NQ_021_02 |
		| BP_C1_NQ_022_01 |
		| BP_C1_NQ_022_02 |
		| BP_C1_NQ_023_01 |
		| BP_C1_NQ_024_01 |
		| BP_C1_NQ_025_01 |
		| BP_C1_NQ_026_01 |
		| letter-HF       |
		| letter-AXA      |