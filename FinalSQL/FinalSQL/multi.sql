select stock.number,sock_company.name,stock.storage,sock_company.type
from stock 
inner join sock_company 
on stock.number = sock_company.number 



select stock.number,stock.max,stock.min,stock_purchase_time.purchase_date
from stock 
inner join stock_purchase_time
on stock.number = stock_purchase_time.number 



select stock.number,company_analysis.name,company_analysis.analysis
from stock 
inner join company_analysis
on stock.number = company_analysis.number



select company_build.name,company_build.build_time,company_build.build_place,company_leader.leader 
from company_build
inner join company_build
on company_build.name = company_leader.name


